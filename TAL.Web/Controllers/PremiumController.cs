using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAL.Core.Interfaces.Repo;
using TAL.Core.ViewModels;

namespace TAL.Web.Controllers
{
    [Route("api/Premium"), Produces("application/json"), EnableCors("AppPolicy")]
    public class PremiumController : Controller
    {
        private readonly IPremiumCalculator _premiumCalculator;

        public PremiumController(IPremiumCalculator premiumCalculator)
        {
            _premiumCalculator = premiumCalculator;
        }
        [HttpPost, Route("CalculateMonthlyPremium")]
        public Premium CalculateMonthlyPremium([FromBody]UserDetails userDetails)
        {
            try
            {
                var premiumAmount = _premiumCalculator.Calculate(userDetails);

                return new Premium() { Name = userDetails.Name, PremiumAmount = premiumAmount };
            }
            catch (Exception)
            {
                //Log error message into the log file
                
                return null;
            }
            
        }
    }
}