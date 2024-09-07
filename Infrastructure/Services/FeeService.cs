using Application.UseCases;
using Domain.Entities;
using Infrastructure.DTOs.Common;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Net;

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
            BaseResponse<Fee> resp = new BaseResponse<Fee>
            {
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
                    resp.Page = 1;
                    resp.PageSize = fees.Count;
                }
            }
            catch (Exception ex)
            {
                resp.Errors.Add(ex.Message);
            }

            return resp;
        }
        public async Task<BaseResponse<Fee>> GetAsync(int? id, int? page, int? pageSize)
        {
            BaseResponse<Fee> resp = new BaseResponse<Fee>
            {
                Total = 0
            };

            try
            {
                resp.Total = _context.Fees.Count();

                IQueryable<Fee> fees = _context.Fees.Where(
                    x => ((null == id || id == 0) || x.Id == id)
                );

                pageSize = null == pageSize || pageSize <= 0 ? 50 : (int)pageSize;
                page = null == page || page <= 0 || pageSize * page > fees.Count() ? 0 : (int)page - 1;

                resp.Results = fees
                                .OrderByDescending(x => x.Id)
                                .Skip((int)pageSize * (int)page)
                                .Take((int)pageSize)
                                .ToList();

                resp.Page = (int)page + 1;
                resp.PageSize = resp.Results.Count;

            }
            catch (Exception ex)
            {
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }


    }
}
