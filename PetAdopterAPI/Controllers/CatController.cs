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
    public class CatController : ApiController
    {
        private readonly PetAdopterDbContext _cat = new PetAdopterDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreateCat([FromBody] CatTable model)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            if (ModelState.IsValid)
            {
                _cat.Cats.Add(model);
                int changeCount = await _cat.SaveChangesAsync();
            }
            return Ok("Ready to adopt!");
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCats()
        {
            List<CatTable> catList = await _cat.Cats.ToListAsync();
            return Ok(catList);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetCatById([FromUri] int id)
        {
            CatTable cat = await _cat.Cats.FindAsync(id);
            if (cat == null) { return NotFound(); }
            return Ok(cat);
        }
        [HttpPost]
        public async Task<IHttpActionResult> UpdateCat([FromUri] int id, [FromBody] CatTable model )
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            CatTable cat = await _cat.Cats.FindAsync(id);
            if (cat == null) { return BadRequest($"No such Id exists {id}"); }
            cat.Name = model.Name;
            cat.Breed = model.Breed;
            cat.Sex = model.Sex;
            cat.Birthdate = model.Birthdate;
            cat.KidFriendly = model.KidFriendly;
            cat.PetFriendly = model.PetFriendly;
            cat.Hypoallergenic = model.Hypoallergenic;
            cat.IsDeclawed = model.IsDeclawed;
            cat.ShelterId = model.ShelterId;
            await _cat.SaveChangesAsync();
            return Ok($"{cat} has been updated!");
        }
        [HttpDelete]
        public async Task<IHttpActionResult> HttpActionResult(int id)
        {
            CatTable cat = await _cat.Cats.FindAsync(id);
            if (cat == null) { return NotFound(); }
            _cat.Cats.Remove(cat);
            if(await _cat.SaveChangesAsync()==1)
            { return Ok("Cat was deleted!"); }
            return InternalServerError();
        }


    }
}

