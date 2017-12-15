[TOC]

### Asp.net Core+InfluxDB+Grafana+AppMetrics在Linux平台上的实践

#### InfluxDB时序数据库安装

```shell
wget https://dl.influxdata.com/influxdb/releases/influxdb-1.4.2.x86_64.rpm

sudo yum localinstall influxdb-1.4.2.x86_64.rpm
```







#### Apache ab压力测试

[Apache下载使用](http://blog.csdn.net/ahaaaaa/article/details/51514175)

[超实用压力测试工具－ab工具](http://www.jianshu.com/p/43d04d8baaf7)

```
ab -n 100 -c 10 http://localhost:10343/api/values

-n:请求数
-c:并发数 
```




[.Net Core 2.0+ InfluxDB+Grafana+App Metrics 实现跨平台的实时性能监控](http://www.cnblogs.com/landonzeng/p/7904402.html)

[ASP.NET Core之跨平台的实时性能监控](http://www.cnblogs.com/GuZhenYin/p/7170010.html)

[ASP.NET Core之跨平台的实时性能监控(2.健康检查)](http://www.cnblogs.com/GuZhenYin/p/7216724.html)

[ASP.NET Core HealthCheck](https://github.com/dotnet-architecture/HealthChecks)