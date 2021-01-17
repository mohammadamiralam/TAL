using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tal.Core.Interfaces.Repo;
using TAL.Core.ViewModels;

namespace TAL.Web.Controllers
{
    [Route("api/Occupation"), Produces("application/json"), EnableCors("AppPolicy")]
    public class OccupationController : Controller
    {
        private readonly IOccupationRepository _occupationRepo;

        public OccupationController(IOccupationRepository occupationRepo)
        {
            _occupationRepo = occupationRepo;
        }

        [HttpGet, Route("GetOccupations")]
        public IEnumerable<Occupation> GetOccupations()
        {
            var occupations = _occupationRepo.GetOccupations();
            return occupations;
        }
    }
}