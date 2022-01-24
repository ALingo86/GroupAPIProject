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
        public float Age { get; }
        [ForeignKey(nameof(Shelter))]
        public string ShelterId { set; get; }



    }
}