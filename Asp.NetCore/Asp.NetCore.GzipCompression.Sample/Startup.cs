using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore.GzipCompression.Sample.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.NetCore.GzipCompression.Sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options=> {
                //是否要对HTTPS的封包进行压缩
                options.EnableForHttps = true;
                //设定要进行压缩的MimeTypes
                //text/plain、text/css、application/javascript、text/html、application/xml、text/xml、application/json、text/json
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new string[]{
                    "image/png",
                    //*.ico
                    "image/x-icon",
                    "text/css",
                    "application/javascript",
                    "text/xml",
                    //*.svg
                    "application/svg+xml"


                });

                //自定义压缩(默认是Gzip压缩)

                //options.Providers.Add<CustomCompressionProvider>();
            });
            //设定Gzip的压缩方
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Fastest;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
