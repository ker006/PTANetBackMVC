using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Common
{
    public class BaseResponse<T>
    {
        public List<T> Results { get; set; } = new List<T>();
        public List<string> Errors { get; set; } = new List<string>();
        public int Total { get; set; } = new int();
    }
}
