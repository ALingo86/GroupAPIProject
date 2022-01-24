using PetAdopterAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Controllers
{
    public class DogTable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Breed { get; set; }

        [Required]
        public string Sex { get; set; }

        public bool IsSterile { get; set; }

        [Required]
        public DateTimeOffset BirthDate { get; set; }

        public float Age
        {

            get
            {
                TimeSpan age = DateTime.Now - BirthDate;
                return (int)Math.Floor(age.TotalDays / 365.24);
            }

        }

        public bool IsAdoptionPending { get; set; }

        public bool IsKidFriendly { get; set; }

        public bool IsPetFriendly { get; set; }

        public bool IsHypoallergenic { get; set; }

        public bool IsHouseTrained { get; set; }


        [ForeignKey(nameof(Shelter))]
        public string Location { get; set; }

        public virtual Shelter shelter { get; set; }

        public DogTable(string name, string breed, string sex, bool isSterile, DateTimeOffset birthDate, bool adoptionPending, bool iskidFriendly, bool ispetFriendly, bool ishypoallergenic, string location)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            BirthDate = birthDate;
            IsAdoptionPending = adoptionPending;
            IsKidFriendly = iskidFriendly;
            IsPetFriendly = ispetFriendly;
            IsHypoallergenic = ishypoallergenic;
            Location = location;
        }
    }

}







