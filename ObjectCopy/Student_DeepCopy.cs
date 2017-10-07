using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace ObjectCopy
{
    /*
     实现深拷贝的几种方法:
     1:反射
     2:序列化\反序列化 （xml序列化\反序列化、 二进制序列化反序列化、DataContractSerializer序列化和反序列化）
     3:表达树    
    */
    [Serializable]
    public class Student_DeepCopy 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        
        public static T DeepCopyWithReflection<T>(T obj)
        {
            var type = obj.GetType();
            //string 和值类型默认是深拷贝
            if (obj is string || type.IsValueType)
            {
                return obj;
            }
            //数组
            if (type.IsArray)
            {
                Type elementType = Type.GetType(type.FullName.Replace("[]", string.Empty));
                var array = obj as Array;
                Array copied = Array.CreateInstance(elementType, array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    copied.SetValue(DeepCopyWithReflection(array.GetValue(i)), i);
                }
                return (T)Convert.ChangeType(copied, obj.GetType());
            }

            object result = Activator.CreateInstance(obj.GetType());

            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(obj, null);
                if (propertyValue==null)
                {
                    continue;
                }
                property.SetValue(result, DeepCopyWithReflection(propertyValue), null);
            }
            return (T)result;
        }

        public static T DeepCopyWithXmlSerialize<T>(T obj)
        {
            object result;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                result = xml.Deserialize(ms);
                ms.Close();
            }
            return (T)result;
        }

        public static T DeepCopyWithBinarySerialize<T>(T obj)
        {
            object result;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                result = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)result;
        }

        public static T DeepCopyWithDataContractSerializer<T>(T obj)
        {
            object result;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                result = serializer.ReadObject(ms);
                ms.Close();
            }
            return (T)result;
        }

        public static T DeepCopyWithExpressionTree<T>(T obj)
        {
            /*
            网上示例:

            https://www.codeproject.com/Articles/1111658/Fast-Deep-Copy-by-Expression-Trees-C-Sharp

            */
            return default(T);
        }
    }


}
