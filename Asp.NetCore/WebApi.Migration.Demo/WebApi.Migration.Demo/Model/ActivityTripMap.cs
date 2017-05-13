using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Migration.Demo.Model
{
    public class ActivityTripMap
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
