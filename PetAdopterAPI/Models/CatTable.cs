﻿using System;
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
        public bool Declawed { get; set; }
        [ForeignKey(nameof(Shelter))]
        public string Location { get; set; }

    }
}