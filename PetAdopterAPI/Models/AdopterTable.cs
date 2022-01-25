using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class AdopterTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public AdopterTable() { }
        public AdopterTable(int id, string firstName, string lastName, string city, string state, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            State = state;
            PhoneNumber = phoneNumber;
        }
    }
}