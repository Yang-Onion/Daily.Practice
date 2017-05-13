using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Migration.Demo.Model
{
    public class Lodging
    {
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public bool IsResort { get; set; }
        public decimal MilesFromNearestAirport { get; set; }
        //只要下面的字段满足以下条件，在生成表时它会自动将它设置为外键

        //[目标类型的键名] 例如：DestinationId
        //[目标类型名称]+[目标类型键名称] 例如：Destination+DestinationId=DestinationDestinationId
        //[导航属性名称]+[目标类型键名称] 例如：Target+DestinationId=TargetDestinationId

        //public int DestinationId { get; set; }
        //public int DestinationDestinationId { get; set; }
        //public int TargetDestinationId { get; set; }

        //不满足上面的3种命名条件,它会当作普通字段,它会自动生成一个外键,外键名称 TargetDestinationId
        //如果，我们就想要把DestId当成和Destination关联的外键,需要打上标签在DestId上加上[ForeignKey("Target")] 或者 在Target属性上加上 [ForeignKey("DestId")]
        //[ForeignKey("Target")]
        public int DestId { get; set; }
        [ForeignKey("DestId")]
        public Destination Target { get; set; }

        //ef会为下面4个导航属性生成4个外键分别是PrimaryContactId,SecondContactId,PrimaryContactForId,SecondContactForId

        //要想PrimaryContact和PrimaryContactFor |SecondContact 和SecondContactFor 分别用一个外键,需要使用 逆导航属性 InverseProperty
        [InverseProperty("PrimaryContactFor")]
        public Person PrimaryContact { get; set; }

        [InverseProperty("SecondContactFor")]
        public Person SecondContact { get; set; }

        //public Person PrimaryContactFor { get; set; }
        //public Person SecondContactFor { get; set; }

    }
}
