using CalculoCDB.Domain.Entities;
using CalculoCDB.Domain.Interfaces;
using CalculoCDB.Service.Services;
using CalculoCDB.Service.CalculoCDB;
using Microsoft.AspNetCore.Mvc;
using CalculoCDB.Service.Validators;
using Microsoft.AspNetCore.Cors;

namespace CalculoCDB.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoCdbController : ControllerBase
    {
        private readonly IBaseService _baseCdbService;

        public CalculoCdbController()
        {
            _baseCdbService = new BaseService();
        }

        [EnableCors("MyPolicy")]
        [HttpGet()]
        public IActionResult Get([FromQuery] Investimento investimento)
        {
            var result = Execute(() =>
            {
                return _baseCdbService.ResgatarAplicacao<InvestimentoValidator>(investimento);
            });

            return result;

        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
