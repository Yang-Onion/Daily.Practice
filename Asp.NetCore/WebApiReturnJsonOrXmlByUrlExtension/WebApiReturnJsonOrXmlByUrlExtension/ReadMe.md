### 让WebApi根据url的后缀来返回json或者xml类型的数据

+ 在action的路由上面加上后缀,并添加FormartFilter特性`[HttpGet("index.{format}"),FormatFilter]`

+ webapi默认是返回json数据,要让它返回xml数据,需要添加一个xml序列化模块`Microsoft.AspNetCore.Mvc.Formatters.Xml`(.net core 2.0 中已经默认包括这个,不需要引入)

+ 配置mvc,让它支持xml序列化数据,现在，我们使用`api/value/index.xml`访问时返回就的就xml格式的数据, 使用`api/values/index.js、api/values/index.png 、api/values/index.json`返回的都是josn格式的数据 

```csharp
 public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options=> {
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("js", MediaTypeHeaderValue.Parse("application/json"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("png", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();
        }
```

[参考资料](https://andrewlock.net/formatting-response-data-as-xml-or-json-based-on-the-url-in-asp-net-core/?utm_source=Andrew+Lock+Signup+Form&utm_campaign=2f59efe790-RSS_EMAIL_CAMPAIGN&utm_medium=email&utm_term=0_68dced5cb4-2f59efe790-194737841)