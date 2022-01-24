using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class isDeclawed
    {
        [ForeignKey(nameof(CatTable))]
        public bool IsDeclawed { get; set; }
       
        [ForeignKey(nameof(CatTable))]
        public string Name { get; set; }
        [ForeignKey(nameof(CatTable))]
        public string Breed { get; set; }
        [ForeignKey(nameof(CatTable))]
        public string Sex { get; set; }
        [ForeignKey(nameof(CatTable))]
        public float Age { get; }
        [ForeignKey(nameof(CatTable))]
        public bool AdoptionPending { get; set; }
        [ForeignKey(nameof(Shelter))]

        public isDeclawed() { }
        public isDeclawed(string name, string breed, string sex,float age, bool adoptionPending, bool isDeclawed, int shelterId)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            Age = age;
            AdoptionPending = adoptionPending;
            IsDeclawed = isDeclawed;
            ShelterId = shelterId;
        }


    }
}