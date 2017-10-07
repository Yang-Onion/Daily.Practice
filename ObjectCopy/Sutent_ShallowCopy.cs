using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectCopy
{
    public class Sutent_ShallowCopy : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    //深拷贝（序列化|反序列化时才需要Serializable）
    [Serializable]
    public class Grade
    {
        public int Id { get; set; }
        public string GradeName { get; set; }

        public override string ToString()
        {
            return $"班级编号:{Id},班级名称:{GradeName}";
        }
    }
}
