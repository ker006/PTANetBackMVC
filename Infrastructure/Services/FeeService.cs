using Domain.Entities;
using Infrastructure.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FeeService
    {
        public async Task<BaseResponse<Fee>> PopulateFeeDb()
        {
            BaseResponse<Fee> resp = new();

            return resp;
        }
    }
}
