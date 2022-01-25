using PetAdopterAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetAdopterAPI.Models
{
    public class PetAdopterDbContext : DbContext
    {
        public PetAdopterDbContext() : base("DefaultConnection") { }
        public DbSet<DomesticTable> Domestics { get; set; }
        public DbSet<ExoticTable> Exotics { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<AdopterTable> Adopters { get; set; }
    }
}