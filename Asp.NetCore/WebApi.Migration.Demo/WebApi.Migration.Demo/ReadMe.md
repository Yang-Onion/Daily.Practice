## EF Core Migration
> 当应用程序部署到远程服务器上时,实现数据库,数据表的自动生成；当表结构发生变化时,重新部署程序,重新访问程序时数据表会自动更新，它不会影响原有的数据
1. 在AppContext(DbContext)的构造函数下配置自动迁移
``` csharp
 public AppContext(DbContextOptions options) : base(options){
            Database.Migrate();
 }
```
2. 当表结构发生变化时,用类似下面的命令生成 迁移文件.

``` csharp
	dotnet ef Migrations add  addAgeForStudent -c AppContext -o ./Migrations
```
3. 重新发布、部署程序，重新访问站点，数据表结构会自动生成，原有数据仍然会存在。当添加了字段不为null时,最会为它赋一个默认值，否则可能会报错(int,bool,datetime类型的字段)

>如果本地能够直接连接远程服务器，那么直接执行dotnet ef  database update -c ApplicationContext -e Development 就可以；但大数情况下，开发环境和生成环境是隔离的,本地是连接不到远程服务器的，所以得按照上面步骤1~步骤3来。

## EF 导航属性  one-to-one one-to-many many-to-many ForeignKey

> 外键表的属性值要带virtual关键字

假设Destination中的一条记录下有上w条Lodging记录

有个逻辑只需要查Destination表数据 如果不用virtual 那么那w条Lodging记录也会被带进来

如果用virtual 那么只有在访问 Destination.Lodgings属性的时候 才去数据库加载.


https://docs.microsoft.com/en-us/ef/core/modeling/relationships

http://www.cnblogs.com/liangxiaofeng/p/5809451.html
http://www.cnblogs.com/Gyoung/archive/2013/01/22/2869782.html

