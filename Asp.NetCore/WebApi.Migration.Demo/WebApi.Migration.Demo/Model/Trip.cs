using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Migration.Demo.Model
{
    public class Trip
    {
        public int TripId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CostUSD { get; set; }
        public byte[] RowVersion { get; set; }
        public ICollection<ActivityTripMap> ActivityTripMaps { get; set; }
    }
}
