using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Common
{
    public class PageableRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PageableRequest()
        {
            Page = 0;
            PageSize = 1000;
        }
    }
}
