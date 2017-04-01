using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Http;

namespace WebApiSwaggerDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //1:引用dll Swashbuckle.AspNetCore
            //2:右键-属性-生成(Build)-输出-xml文档文件（本项目将这个配置为swagger.xml）
            //3:配置启动页面,配置Properties/launchSettings.json中的profiles下的 "launchUrl": "swagger/index.html"
            //4:www/js/swagger_lang.js 汉化文字，并在Configure中使用

            //services.AddSwaggerGen();
            //services.ConfigureSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1",
            //        new Info {
            //            Title = "物流平台API_v1",
            //            Version = "v1",
            //            Description = "手机端Api",
            //            TermsOfService = "None"
            //        }
            //     );

            //    options.SwaggerDoc("v2",
            //        new Info {
            //            Title = "物流平台API_v2",
            //            Version = "v2",
            //            Description = "手机端pi",
            //            TermsOfService = "None"
            //        }
            //     );
            //    options.IncludeXmlComments("swagger.xml");
            //    options.DescribeAllEnumsAsStrings();
            //});

            //使用上面的方法也可以
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v3",
                    new Info {
                        Title = "物流平台API_v3",
                        Version = "v3",
                        Description = "手机端api",
                        TermsOfService = "服务条款",

                        //Contact = new Contact { Name = "me", Email = "me@me.com", Url = "http://github.com/me" },
                       //License = new License { Name = "me", Url = "http://github.com/me" }
                    });

                options.DescribeAllEnumsAsStrings();
                options.IncludeXmlComments("swagger.xml");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            //nuget Serilog.Extensions.Logging.File
            loggerFactory.AddFile(Configuration.GetSection("Logging"));

            app.UseStaticFiles();

            //auth2.0 
            //if (!env.IsDevelopment()) {
            //    app.UseWhen(context => context.Request.Path.StartsWithSegments(new PathString("/apid")), builder=> builder.UseOAuthValidation());
            //    app.UseOpenIdConnectServer(options =>
            //    {
                    
            //    });
            //}

            app.UseMvc();

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });

            app.UseSwaggerUi(c =>
            {
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                //c.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "V3 Docs");
                c.InjectOnCompleteJavaScript("/js/swagger_lang.js");
               //c.ConfigureOAuth2(clientId: "1", clientSecret: "123", realm: "", appName: "driver");
            });
        }
    }
}
