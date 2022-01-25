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
    public class DomesticController : ApiController
    {
        private readonly PetAdopterDbContext _domestic = new PetAdopterDbContext();

        // POST (create)
        // api/Dogs
        [HttpPost]
        public async Task<IHttpActionResult> CreateDog([FromBody] DomesticTable model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty.");
            }

            // If valid
            if (ModelState.IsValid)
            {
                // Store in the database
                _domestic.Domestics.Add(model);
                int changeCount = await _domestic.SaveChangesAsync();

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
            List<DomesticTable> dogs = await _domestic.Domestics.ToListAsync();
            return Ok(dogs);
        }

        // GET By ID
        // api/Dogs/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            DomesticTable dog = await _domestic.Domestics.FindAsync(id);

            if (dog != null)
            {
                return Ok(dog);
            }

            return NotFound();
        }

        // GET By Breed
        // api/Dogs/{breed}
        [HttpGet]
        public async Task<IHttpActionResult> GetByBreed([FromUri] string breed)
        {
            DogTable dog = await _dog.Dogs.FindAsync(breed);

            if(dog != null)
            {
                return Ok(dog);
            }

            return NotFound();
        }

        // PUT (update)
        // api/Dogs/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateDog([FromUri] int id, [FromBody] DogTable updatedDog)
        {
            // check to see if ids match
            if(id != updatedDog?.Id)
            {
                return BadRequest("Id does not match.");
            }

            // Check
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the dog in the database
            DogTable dog = await _dog.Dogs.FindAsync(id);

            // If the character doesn't exist
            if (dog is null)
                return NotFound();

            // Update the properties
            dog.Name = updatedDog.Name;
            dog.Breed = updatedDog.Breed;
            dog.Sex = updatedDog.Sex;
            dog.IsSterile = updatedDog.IsSterile;
            dog.BirthDate = updatedDog.BirthDate;
            dog.IsAdoptionPending = updatedDog.IsAdoptionPending;
            dog.IsKidFriendly = updatedDog.IsKidFriendly;
            dog.IsPetFriendly = updatedDog.IsPetFriendly;
            dog.IsHypoallergenic = updatedDog.IsHypoallergenic;
            dog.IsHouseTrained = updatedDog.IsHouseTrained;
            dog.Location = dog.Location;

            // Save the changes
            await _dog.SaveChangesAsync();

            return Ok("The dog's information has been updated.");
        }

        // DELETE
        // api/Dogs/{id}
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteDog([FromUri] int id)
        {
            DogTable dog = await _dog.Dogs.FindAsync(id);

            if (dog is null)
                return NotFound();

            _dog.Dogs.Remove(dog);

            if(await _dog.SaveChangesAsync() == 1)
            {
                return Ok("The dog was deleted.");
            }

            return InternalServerError();
        }
    }
}
