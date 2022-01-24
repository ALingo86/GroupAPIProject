﻿using PetAdopterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetAdopterAPI.Controllers
{
    public class HypoallergenicController : ApiController
    {
        private readonly PetAdopterDbContext _dog = new PetAdopterDbContext();

        // GET by HypoAllergenic
        // api/Dogs/{isHypoallergenic}
        [HttpGet]
        public IHttpActionResult GetHypo()
        {
            
            List<DogTable> hypoDogs = new List<DogTable>();
            foreach (DogTable dog in _dog.Dogs)
            {
                if (dog.IsHypoallergenic == true)
                {
                    hypoDogs.Add(dog);
                }
                return (IHttpActionResult)hypoDogs;
            }

            return InternalServerError();
           
        }
    }
}


