using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class isKidFriendlyCat
    {
        [ForeignKey(nameof(CatTable))]
        public bool IsKidFriendly { get; set; }
    }
}