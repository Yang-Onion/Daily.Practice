.net core ef 使用


参考文章：http://www.c-sharpcorner.com/article/getting-started-with-asp-net-core-ef-core-using-sql-server-on-windows/

注意使用.net core ef时添加下面几个引用

"Microsoft.EntityFrameworkCore": "1.0.1",
"Microsoft.EntityFrameworkCore.SqlServer": "1.0.1",
"Microsoft.EntityFrameworkCore.Tools": "1.0.0-preview2-final"


Migration常用命令

Add-Migration
Update-Database
