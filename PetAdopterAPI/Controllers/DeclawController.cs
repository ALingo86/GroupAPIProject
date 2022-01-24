using PetAdopterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetAdopterAPI.Controllers
{
    public class DeclawController : ApiController
    {
        private readonly PetAdopterDbContext _cat = new PetAdopterDbContext();
        [HttpGet]
        public IHttpActionResult GetDeclawedCats()
        {
            List<CatTable> declawedList = new List<CatTable>();
            foreach (CatTable cat in _cat.Cats)
            {
                if (cat.IsDeclawed == true)
                {
                    declawedList.Add(cat);
                }
                return (IHttpActionResult)declawedList;
            }
            return InternalServerError();
        }
    }
}
