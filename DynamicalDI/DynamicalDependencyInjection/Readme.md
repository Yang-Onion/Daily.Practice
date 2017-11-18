### 动态注入
> 动态注入,通过反射动态的拿到interface和implservice,然后，动态配置它们的DI。

> .net core 内置的DI不支持动态注入

> 使用第三的的DI框架 Autofac

>using Autofac;
>using Autofac.Extensions.DependencyInjection;

[Autofac动态注入](http://cecilphillip.com/di-conventions-with-aspnetcore/)