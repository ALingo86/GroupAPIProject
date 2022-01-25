using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class ExoticTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public bool Sterile { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public float Age
        {

            get
            {
                TimeSpan age = DateTime.Now - Birthdate;
                return (int)Math.Floor(age.TotalDays / 365.24);
            }

        }
        [Required]
        public bool IsAdoptionPending { get; set; }
        [Required]
        public bool IsKidFriendly { get; set; }
        [Required]
        public bool IsPetFriendly { get; set; }
        [Required]
        public bool IsHypoallergenic { get; set; }
        [Required]
        public bool IsLegalInCity { get; set; }
        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
        public ExoticTable(int id, string name, string breed, string species, bool isSterile, DateTime birthdate, float age, bool isadoptionPending, bool isKidFriendly, bool isPetFriendly, bool ishypoallegernic, bool islegalInCity, int shelterId)
        {
            id = Id;
            name = Name;
            breed = Breed;
            species = Species;
            isSterile = Sterile;
            birthdate = Birthdate;
            age = Age;
            isadoptionPending = IsAdoptionPending;
            isKidFriendly = IsKidFriendly;
            isPetFriendly = IsPetFriendly;
            ishypoallegernic = IsHypoallergenic;
            islegalInCity = IsLegalInCity;
            shelterId = ShelterId;

        }
    }
}