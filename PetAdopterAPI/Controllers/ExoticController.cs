using PetAdopterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PetAdopterAPI.Controllers
{
    public class ExoticController : ApiController
    {
        private readonly PetAdopterDbContext _exotic = new PetAdopterDbContext();

        //create
        [HttpPost]
        public async Task<IHttpActionResult> CreateExotic([FromBody] ExoticTable exotic)
        {
            if (exotic is null)
            {
                return BadRequest("Please enter a value");
            }
            if (ModelState.IsValid)
            {
                _exotic.Exotics.Add(exotic);
                int ExoticCount = await _exotic.SaveChangesAsync();

                return Ok("Your pet has been posted!");
            }
            return BadRequest(ModelState);
        }

        //Get all exotics
        [HttpGet]
        public async Task<IHttpActionResult> GetAllExotic()
        {
            List<ExoticTable> exotics = await _exotic.Exotics.ToListAsync();
            return Ok(exotics);
        }
        //Get By Species
        [HttpGet]
        public async Task<IHttpActionResult> GetBySpecies([FromUri] string species)
        {
            ExoticTable exotic = await _exotic.Exotics.FindAsync(species);

            if (exotic is null)
            {
                return NotFound();
            }
            return Ok(exotic.Species);
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdateExotic([FromUri] int id, [FromBody] ExoticTable updatedExotic)
        {
            if (id != updatedExotic.Id)
            {
                return BadRequest("Please enter a valid Id");
            }
            ExoticTable exotic = await _exotic.Exotics.FindAsync(id);
            if (exotic is null)
            {
                return NotFound();
            }

            exotic.Name = updatedExotic.Name;
            exotic.Sex = updatedExotic.Sex;
            exotic.Breed = updatedExotic.Breed;
            exotic.Birthdate = updatedExotic.Birthdate;
            exotic.AdoptionPending = updatedExotic.AdoptionPending;
            exotic.IsKidFriendly = updatedExotic.IsKidFriendly;
            exotic.IsPetFriendly = updatedExotic.IsPetFriendly;
            exotic.LegalInCity = updatedExotic.LegalInCity;
            exotic.Location = updatedExotic.Location;
            exotic.Sterile = updatedExotic.Sterile;
            exotic.Hypoallergenic = updatedExotic.Hypoallergenic;

            await _exotic.SaveChangesAsync();

            return Ok("The animals info has been saved");
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteExotic([FromUri] int id)
        {
            ExoticTable exotic = await _exotic.Exotics.FindAsync(id);
            if (exotic == null)
                return NotFound();

            _exotic.Exotics.Remove(exotic);

            if (await _exotic.SaveChangesAsync() == 1)
            {
                return Ok("The pet has been removed");
            }
            return BadRequest();
        }
    }
}