using System;
using System.Collections.Generic;
using System.Text;

namespace AttributeDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ProducerAttribute:Attribute
    {
        public ProducerAttribute()
        {
        }

        public string Topic { get; set; }
        public string Group { get; set; }
    }
}
