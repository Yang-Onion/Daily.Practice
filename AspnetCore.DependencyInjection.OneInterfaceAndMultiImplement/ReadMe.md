### Asp.net Core Dependency Injection  One Interface And Multi Implement

#### 使用工厂方法


#### 添加`Microsoft.Extensions.DependencyInjection`包,根据

``` csharp
 
 //构造函数注入 IServiceProvider services
 _pay = services.First(g=>g.GetType()==typeof(AliPay));

```

#### 包裹一层接口



#### 使用第三方的IOC组件  Unity or StructureMap

[How to register multiple implementations of the same interface in Asp.Net Core?](https://stackoverflow.com/questions/39174989/how-to-register-multiple-implementations-of-the-same-interface-in-asp-net-core)