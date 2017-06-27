### 需要引用的包
>可以使用dotnet user-secrets命令将数据存储到json文件中
1. Microsoft.Extensions.SecretManager.Tools

>可以通过.NET Core的配置系统访问存储在json文件中的数
2. Microsoft.Extensions.Configuration.UserSecrets

### dotnet user-secrets cli

|命令|描述|语法|
|---|---|---|
|clear|	删除程序中所有的secrets|	dotnet user-secrets clear|
|list	|列举程序中所有的secrets|	dotnet user-secrets list|
|remove	|删除指定的secret|	dotnet user-secrets remove NameOfSecret|
|set	|设置secret|	dotnet user-secrets set NameOfSecret ValueOfSecret|
