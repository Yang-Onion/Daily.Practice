### 对象拷贝

####  基本概念

1. 浅拷贝:拷贝一个对象时，仅仅拷贝对象的引用进行拷贝，但是拷贝对象和源对象还是引用同一份实体。此时，其中一个对象的改变都会影响到另一个对象。

2. 深拷贝:拷贝一个对象时，不仅仅把对象的引用进行复制，还把该对象引用的值也一起拷贝

> .NET中 值类型 默认是深拷贝的，而对于引用类型，默认实现的是浅拷贝。所以对于类中引用类型的属性改变时，其另一个对象也会发生改变。



#### 深拷贝实现方式

1.反射

2.序列化\反序列化 （xml序列化\反序列化、 二进制序列化反序列化、DataContractSerializer序列化和反序列化）

3.表达树



####  参考资料

[深入解析深拷贝和浅拷贝](https://www.kancloud.cn/wizardforcel/learning-hard-csharp/111515)
[浅谈C#浅拷贝和深拷贝](http://www.cnblogs.com/xufei/p/copyDeep.html)
[Fast Deep Copy by Expression Trees (C#)](https://www.codeproject.com/Articles/1111658/Fast-Deep-Copy-by-Expression-Trees-C-Sharp)
