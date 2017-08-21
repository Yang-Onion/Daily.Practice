### Electron写HelloWorld Demo并打包成exe和.msi文件

#### 打造你第一个 Electron 应用 
[打造你第一个 Electron 应用](https://github.com/electron/electron/blob/master/docs-translations/zh-CN/tutorial/quick-start.md)


#### 手把手教你把前端代码打包成msi和exe文件

[手把手教你把前端代码打包成msi和exe文件](http://yohnz.win/2016/10/11/%E6%89%8B%E6%8A%8A%E6%89%8B%E6%95%99%E4%BD%A0%E6%8A%8A%E5%89%8D%E7%AB%AF%E4%BB%A3%E7%A0%81%E6%89%93%E5%8C%85%E6%88%90msi%E5%92%8Cexe%E5%BA%94%E7%94%A8/)


#### 常用命令

1. electron .    运行程序

2. npm run-script package  打包成exe

3. 下面的配置非常重要

```javascript
 "scripts": {
    "start": "electron .",
    "package": "electron-packager ./ app1 --platform=win32 --arch=x64 --electron-version 1.7.5 --overwrite --ignore=node_modules/electron-*"
  }
```


