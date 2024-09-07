using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Fee
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public decimal? HourlyImbalanceFee { get; set; }
        public decimal? ImbalanceFee { get; set; }
        public decimal? PeakLoadFee { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTimeOffset TimestampUTC { get; set; }
        public decimal? VolumeFee { get; set; }
        public int WeeklyFee { get; set; }
    }
}
