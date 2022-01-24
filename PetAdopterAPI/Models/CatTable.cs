using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class CatTable
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
        public DateTimeOffset Birthdate { get; set; }
        public float Age
        {
            
                get {
                    TimeSpan age = DateTime.Now - Birthdate;
                    return (int)Math.Floor(age.TotalDays / 365.24);
                }
            
        }
        public bool AdoptionPending { get; set; }
        public bool KidFriendly { get; set; }
        public bool PetFriendly { get; set; }
        public bool Hypoallergenic { get; set; }
        public bool IsDeclawed { get; set; }
        [ForeignKey(nameof(Shelter))]
        public Shelter Shelter { get; set; }
        public CatTable() { }
        public CatTable (string name, string breed, string sex, bool isSterile, DateTimeOffset birthDate,  bool adoptionPending, bool kidFriendly, bool petFriendly, bool hypoallergenic, bool isDeclawed, Shelter model )
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            Birthdate = birthDate;
            AdoptionPending = adoptionPending;
            KidFriendly = kidFriendly;
            PetFriendly = petFriendly;
            Hypoallergenic = hypoallergenic;
            IsDeclawed = isDeclawed;
            Shelter = model;
        }

    }
}