﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQLDemo.MiddleWare.GraphTypes;
using GraphQLDemo.Repository;
using Microsoft.AspNetCore.Http;

namespace GraphQLDemo.MiddleWare
{
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IBookRepository _bookRepository;
        public GraphQLMiddleware(RequestDelegate next,IBookRepository bookRepository) {
            _next = next;
            _bookRepository = bookRepository;
        }

        public async Task Invoke(HttpContext httpContext) {
            var sent = false;
            if (httpContext.Request.Path.StartsWithSegments("/graph")) {
                using (var sr = new StreamReader(httpContext.Request.Body)) {
                    var query = await sr.ReadToEndAsync();
                    if (!string.IsNullOrEmpty(query)) {
                        var schema = new Schema { Query = new BooksQuery(_bookRepository) };
                        var result = await new DocumentExecuter().ExecuteAsync(options =>
                        {
                            options.Schema = schema;
                            options.Query = query;
                        }).ConfigureAwait(false);
                        CheckForErrors(result);
                        await WriteResult(httpContext, result);
                        sent = true;
                    }
                }
            }
            if (!sent) {
                await _next(httpContext);
            }
        }


        private void CheckForErrors(ExecutionResult result) {
            if (result.Errors?.Count>0) {
                var errors = new List<Exception>();
                foreach (var error in result.Errors) {
                    var ex = new Exception(error.Message);
                    if (error.InnerException != null) {
                        ex = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(ex);
                }
                throw new AggregateException(errors);
            }
        }
        
        private async Task WriteResult(HttpContext httpContext,ExecutionResult result) {
            var json = new DocumentWriter(indent: true).Write(result);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
    }
}
