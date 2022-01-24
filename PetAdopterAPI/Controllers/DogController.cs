using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetAdopterAPI.Controllers
{
    public class DogController : ApiController
    {
        private readonly DogDbContext _dog = new DogDbContext();

        // POST (create)
        // api/Dog
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
                _dog.Dog.Add(model);
                int changeCount = await _dog.SaveChangesAsync();

                return Ok("Ready to adopt!");
            }

            // Reject if not valid
            return BadRequest(ModelState);
        }

        // GET ALL
        // api/Dog
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<DogTable> dogs = await _dog.Dog.ToListAsync();
            return Ok(dogs);
        }

        // GET By ID
        // api/Dog/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            DogTable dog = await _dog.Dog.FindAsync(id);

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
