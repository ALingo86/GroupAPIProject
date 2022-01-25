namespace PetAdopterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdopterTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DomesticTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Breed = c.String(),
                        Sex = c.String(nullable: false),
                        IsSterile = c.Boolean(nullable: false),
                        BirthDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsAdoptionPending = c.Boolean(nullable: false),
                        IsKidFriendly = c.Boolean(nullable: false),
                        IsPetFriendly = c.Boolean(nullable: false),
                        IsHypoallergenic = c.Boolean(nullable: false),
                        IsHouseTrained = c.Boolean(nullable: false),
                        IsDeclawed = c.Boolean(nullable: false),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shelters", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
            CreateTable(
                "dbo.Shelters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShelterId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExoticTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Breed = c.String(nullable: false),
                        Species = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        Sterile = c.Boolean(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        AdoptionPending = c.Boolean(nullable: false),
                        IsKidFriendly = c.Boolean(nullable: false),
                        IsPetFriendly = c.Boolean(nullable: false),
                        Hypoallergenic = c.Boolean(nullable: false),
                        LegalInCity = c.Boolean(nullable: false),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shelters", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExoticTables", "ShelterId", "dbo.Shelters");
            DropForeignKey("dbo.DomesticTables", "ShelterId", "dbo.Shelters");
            DropIndex("dbo.ExoticTables", new[] { "ShelterId" });
            DropIndex("dbo.DomesticTables", new[] { "ShelterId" });
            DropTable("dbo.ExoticTables");
            DropTable("dbo.Shelters");
            DropTable("dbo.DomesticTables");
            DropTable("dbo.AdopterTables");
        }
    }
}
