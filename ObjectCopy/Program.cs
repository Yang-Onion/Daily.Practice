using System;

namespace ObjectCopy
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             *浅拷贝:拷贝一个对象时，仅仅拷贝对象的引用进行拷贝，但是拷贝对象和源对象还是引用同一份实体。此时，其中一个对象的改变都会影响到另一个对象。
             *深拷贝:拷贝一个对象时，不仅仅把对象的引用进行复制，还把该对象引用的值也一起拷贝
             * 
             .NET中 值类型 默认是深拷贝的，而对于引用类型，默认实现的是浅拷贝。所以对于类中引用类型的属性改变时，其另一个对象也会发生改变。
             
             */

            #region 浅拷贝

            Sutent_ShallowCopy orgin = new Sutent_ShallowCopy
            {
                Id = 1,
                Name="张三",
                Grade=new Grade { Id=1001,GradeName="一年级一班"}
            };

            Console.WriteLine($"{orgin.Id} \t {orgin.Name} \t {orgin.Grade.ToString()}");
            var copy = orgin.Clone() as Sutent_ShallowCopy;

            copy.Id = 20170001;
            //Name是string引用类型,但它还是用的深拷贝（特殊处理）,把Name的值给拷贝过来了,所以,我们在copy中修改Name的值,并不会影响orgin中Name的值
            copy.Name = "张三三";
            copy.Grade.Id = 20001001;
            copy.Grade.GradeName = "三年二班";

            Console.WriteLine($"{copy.Id} \t {copy.Name} \t {copy.Grade.ToString()}");

            Console.WriteLine($"{orgin.Id} \t {orgin.Name} \t {orgin.Grade.ToString()}");

            #endregion

            #region 深拷贝
            Student_DeepCopy deepOrgin = new Student_DeepCopy
            {
                Id = 1,
                Name = "张三",
                Grade = new Grade { Id = 1001, GradeName = "一年级一班" }
            };

            Console.WriteLine($"{deepOrgin.Id} \t {deepOrgin.Name} \t {deepOrgin.Grade.ToString()}");

            var deepCopy = Student_DeepCopy.DeepCopyWithBinarySerialize(deepOrgin);


            deepCopy.Id = 20170001;
            //Name是string引用类型,但它还是用的深拷贝（特殊处理）,把Name的值给拷贝过来了,所以,我们在copy中修改Name的值,并不会影响orgin中Name的值
            deepCopy.Name = "张三三";
            deepCopy.Grade.Id = 20001001;
            deepCopy.Grade.GradeName = "三年二班";

            Console.WriteLine($"{deepCopy.Id} \t {deepCopy.Name} \t {deepCopy.Grade.ToString()}");

            Console.WriteLine($"{deepOrgin.Id} \t {deepOrgin.Name} \t {deepOrgin.Grade.ToString()}");

            #endregion

            Console.ReadKey();
        }
    }
}
