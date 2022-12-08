using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using E_Wallet.Domain.Dto;

namespace E_WalletTask_GRP_B.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConcverterController : ControllerBase
    {
        public IHttpClientFactory _httpClientFactory;

        public ConcverterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("GetCurrency")]
        public async Task<IActionResult> GetApi()
        {
            try
            {
                var httpClieant = _httpClientFactory.CreateClient();
                var BaseAddress = new Uri("https://open.er-api.com/v6/latest/USD");

                using (var response = await httpClieant.GetAsync(BaseAddress, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    var stream = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RateConversionDTO>(stream);
                    return Ok(result);
                }

            }
            catch (Exception)
            {

                throw;
            }        
              
            
        }

        //[HttpGet("Converter")]
        //public Task<IActionResult> ConvertCurrency(string rate, double amount)
        //{
        //    return Ok();
        //}

    }
   
}
