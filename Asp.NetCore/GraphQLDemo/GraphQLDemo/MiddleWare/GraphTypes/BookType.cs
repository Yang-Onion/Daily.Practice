using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Model;
using GraphQL;
using GraphQL.Types;

namespace GraphQLDemo.MiddleWare.GraphTypes
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType() {
            Field(x => x.Isbn).Description("The isbn of the book.");
            Field(x => x.Name).Description("The name of the book.");
            Field<AuthorType>("author");
        }
    }
}
