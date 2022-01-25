using PetAdopterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetAdopterAPI.Controllers
{
    public class LegallityController : ApiController
    {
        private readonly ApplicationDbContext _exotic = new ApplicationDbContext();

        // GET by Legallity
        // api/Dogs/{isLegal}
        [HttpGet]
        public IHttpActionResult GetLegal()
        {

            List<ExoticTable> legalExotics = new List<ExoticTable>();
            foreach (ExoticTable exotic in _exotic.Exotics)
            {
                if (exotic.IsLegalInCity == true)
                {
                    legalExotics.Add(exotic);
                }
                return (IHttpActionResult)legalExotics;
            }

            return InternalServerError();

        }
    }
}
