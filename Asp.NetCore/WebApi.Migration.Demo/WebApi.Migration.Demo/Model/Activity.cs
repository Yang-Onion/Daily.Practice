using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Migration.Demo.Model
{
    public class Activity
    {
        public int ActivityId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<ActivityTripMap> ActivityTripMaps { get; set; }
    }

}
