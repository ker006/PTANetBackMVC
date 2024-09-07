using Application.UseCases;
using Domain.Entities;
using Infrastructure.DTOs.Common;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class FeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly FeeUseCases _feeUseCases;
        private readonly IConfiguration _configuration;

        public FeeService(ApplicationDbContext context, FeeUseCases feeUseCases, IConfiguration configuration)
        {
            _context = context;
            _feeUseCases = feeUseCases;
            _configuration = configuration;
        }

        public async Task<BaseResponse<Fee>> PopulateFeeDbAsync()
        {
            BaseResponse<Fee> resp = new BaseResponse<Fee> {
                Total = 0
            };

            try
            {
                HttpClient HttpClient = new HttpClient();
                string url = _configuration["OpenDataEssetURL"];
                HttpResponseMessage OpenDataEssetResponse = await HttpClient.GetAsync(url);
                if (OpenDataEssetResponse != null && OpenDataEssetResponse.StatusCode == HttpStatusCode.OK)
                {
                    string result = await OpenDataEssetResponse.Content.ReadAsStringAsync();
                    List<Fee> fees = JsonConvert.DeserializeObject<List<Fee>>(result);

                    _context.AddRange(fees);
                    _context.SaveChanges();

                    resp.Results = fees;
                    resp.Total = fees.Count;
                }
            }
            catch (Exception ex)
            {
                resp.Errors.Add(ex.Message);
            }

            return resp;
        }
    }
}
