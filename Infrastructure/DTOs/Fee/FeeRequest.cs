using Infrastructure.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Fee
{
    public class FeeRequest: PageableRequest
    {
        public FeeFilters? Filters { get; set; }
    }
}
