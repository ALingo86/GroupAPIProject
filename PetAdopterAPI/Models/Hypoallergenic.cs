using PetAdopterAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class isHypoallergenicCat
    {
        [ForeignKey(nameof(CatTable))]
        public bool IsHypoallergenic { get; set; }

    }

    public class isHypoallergenicDog 
    {
        [ForeignKey(nameof(DogTable))]
        public bool IsHypoallergenic { get; set; }
    }

    public class isHypoallergenicExotic
    {
        [ForeignKey(nameof(ExoticTable))]
        public bool IsHypoallergenic { get; set; }
    }
}

