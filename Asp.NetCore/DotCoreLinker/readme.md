### 使用ILLink减小发布后应用程序的大小的大小

#### 参考链接
[.NET Core 2.0应用程序大小减少50％  ](http://www.cnblogs.com/linezero/p/7477233.html)

#### 参加package
```
  dotnet add package ILLinke.Tasks -v 0.1.4-preview-906439
```

#### 常用命令

1. win10 包含linker的发布`dotnet publish -c release -r win10-x64 -o linker`
2. win10 ==不==包含linker的发布 `dotnet publish -c release -r win10-x64 -o nolinker /p:LinkDuringPublish=false`
3. win10 包含linker的发布 查看那些包有压缩 `dotnet publish -c release -r win10-x64 -o linker /p:ShowLinkerSizeComparison=true`
