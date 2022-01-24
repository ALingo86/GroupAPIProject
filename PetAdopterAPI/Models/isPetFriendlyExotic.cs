using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class isPetFriendlyExotic
    {
        [ForeignKey(nameof(ExoticTable))]
        public bool IsPetFriendly { get; set; }
    }
}