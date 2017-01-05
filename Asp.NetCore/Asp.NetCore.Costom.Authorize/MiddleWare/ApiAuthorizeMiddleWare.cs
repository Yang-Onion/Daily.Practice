using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Asp.NetCore.Costom.Authorize.MiddleWare
{
    public class ApiAuthorizeMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ApiAuthorizeOptions _options;

        public ApiAuthorizeMiddleWare(RequestDelegate next, IOptions<ApiAuthorizeOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            await AuthorizeCheck(context);
            await _next.Invoke(context);
        }

        private async Task AuthorizeCheck(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var requestMothod = context.Request.Method.ToUpper();
            string applicationId = string.Empty;
            string timestamp = string.Empty;
            string applicationPassword = string.Empty;
            string nonce = string.Empty;
            string signature = string.Empty;
            if (requestMothod.Equals("POST"))
            {
                var formCollection = context.Request.Form;
                applicationId = formCollection["applicationId"].ToString();
                applicationPassword = formCollection["applicationPassword"].ToString();
                timestamp = formCollection["timestamp"].ToString();
                nonce = formCollection["nonce"].ToString();
                signature = formCollection["signature"].ToString();

            }
            else
            {
                var queryStrings = context.Request.Query;
                applicationId = queryStrings["applicationId"].ToString();
                applicationPassword = queryStrings["applicationPassword"].ToString();
                timestamp = queryStrings["timestamp"].ToString();
                nonce = queryStrings["nonce"].ToString();
                signature = queryStrings["signature"].ToString();
            }

            string computeSignature = HMACMD5Helper.GetEncryptResult($"{applicationId}-{timestamp}-{nonce}",_options.EncryptKey);
            double tmpTimestamp;
            if (computeSignature.Equals(signature) && double.TryParse(timestamp, out tmpTimestamp))
            {
                if (CheckExpiredTime(tmpTimestamp,_options.ExpiredSecond))
                {
                    await TimeOut(context);
                }
                await CheckApplication(context, applicationId, applicationPassword);
            }
            else
            {
                await NoAuthorized(context);
            }

        }


        #region private method

        /// <summary>
        /// not authorized request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task NoAuthorized(HttpContext context)
        {
            BaseResponseResult response = new BaseResponseResult
            {
                Code = "401",
                Message = "You are not authorized!"
            };
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        /// <summary>
        /// timeout request 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task TimeOut(HttpContext context)
        {
            BaseResponseResult response = new BaseResponseResult
            {
                Code = "408",
                Message = "Time Out!"
            };
            context.Response.StatusCode = 408;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        /// <summary>
        /// check the expired time
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="expiredSecond"></param>
        /// <returns></returns>
        private bool CheckExpiredTime(double timestamp, double expiredSecond)
        {
            double now_timestamp = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            return (now_timestamp - timestamp) > expiredSecond;
        }

        private async Task CheckApplication(HttpContext context, string applicationId, string applicationPassword)
        {
            var application =GetAllApplications().FirstOrDefault(g => g.ApplicationId.Equals(applicationId));
            if (application==null || !applicationPassword.Equals(application.ApplicationPassword))
            {
                await NoAuthorized(context);
            }
        }

        /// <summary>
        /// return the application infomations
        /// </summary>
        /// <returns></returns>
        private IList<ApplicationInfo> GetAllApplications()
        {
            return new List<ApplicationInfo>()
            {
                new ApplicationInfo { ApplicationId="1", ApplicationName="Member", ApplicationPassword ="123"},
                new ApplicationInfo { ApplicationId="2", ApplicationName="Order", ApplicationPassword ="123"}
            };
        }

        #endregion
    }
}
