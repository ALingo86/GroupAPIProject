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
    public class DogController : ApiController
    {
        private readonly PetAdopterDbContext _dog = new PetAdopterDbContext();

        // POST (create)
        // api/Dogs
        [HttpPost]
        public async Task<IHttpActionResult> CreateDog([FromBody] DogTable model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty.");
            }

            // If valid
            if (ModelState.IsValid)
            {
                // Store in the database
                _dog.Dogs.Add(model);
                int changeCount = await _dog.SaveChangesAsync();

                return Ok("Ready to adopt!");
            }

            // Reject if not valid
            return BadRequest(ModelState);
        }

        // GET ALL
        // api/Dogs
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<DogTable> dogs = await _dog.Dogs.ToListAsync();
            return Ok(dogs);
        }

        // GET By ID
        // api/Dogs/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            DogTable dog = await _dog.Dogs.FindAsync(id);

            if (dog != null)
            {
                return Ok(dog);
            }

            return NotFound();
        }

        // GET By Breed
        // api/Dog/{breed}
        [HttpGet]
        public async Task<IHttpActionResult> GetByBreed([FromUri] string breed)
        {
            DogTable dog = await _dog.Dog.FindAsync(breed);
        }
    }
}
