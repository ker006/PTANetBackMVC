using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fee
    {
        string Country;
        decimal? HourlyImbalanceFee;
        decimal? ImbalanceFee;
        decimal? PeakLoadFee;
        DateTime Timestamp;
        DateTimeOffset TimestampUTC;
        decimal? VolumeFee;
        int WeeklyFee;
    }
}
