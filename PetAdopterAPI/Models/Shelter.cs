using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class Shelter
    {
        [Key]
        public int Id { get; set; }

        public int ShelterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required] 
        public string State { get; set; }

        public float Rating { get; set; }


        public Shelter() { }

        public Shelter(string name, string city, string state, float rating)
        {
            Name = name;
            City = city;
            State = state;
            Rating = rating;
        }

    }

    
}