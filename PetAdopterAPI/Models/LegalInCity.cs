using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class LegalInCity
    {
        [ForeignKey(nameof(ExoticTable))]
        public bool isLegalInCity { get; set; }
    }
}