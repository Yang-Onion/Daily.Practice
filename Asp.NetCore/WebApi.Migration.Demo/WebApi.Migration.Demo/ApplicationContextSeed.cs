using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using WebApi.Migration.Demo.Model;

namespace WebApi.Migration.Demo { 
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory, int? retry = 0) {
            int retryForAvaiability = retry.Value;
            try {
                var context = (AppContext)applicationBuilder.ApplicationServices.GetService(typeof(AppContext));
                //context.Database.EnsureCreated();
                if (!context.Student.Any()) {
                    context.Student.AddRange(GetApplicationDefault());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex) {
                if (retryForAvaiability < 10) {
                    retryForAvaiability++;
                    var log = loggerFactory.CreateLogger("appdbcontext seed");
                    log.LogError(ex.Message);
                    await SeedAsync(applicationBuilder, loggerFactory, retryForAvaiability);
                }
            }
        }

        public static IEnumerable<Student> GetApplicationDefault() {
            return new Student[] {
                new Student(){
                    StuName="张三"
                },
                new Student(){
                    StuName="李四"
                }
            };
        }
    }
}
