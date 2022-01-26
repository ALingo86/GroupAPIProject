namespace PetAdopterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixeddatasource : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdopterTable",
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
                "dbo.DomesticTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Species = c.String(nullable: false),
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
                .ForeignKey("dbo.Shelter", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
            CreateTable(
                "dbo.Shelter",
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
                "dbo.ExoticTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Breed = c.String(nullable: false),
                        Species = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        Sterile = c.Boolean(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        IsAdoptionPending = c.Boolean(nullable: false),
                        IsKidFriendly = c.Boolean(nullable: false),
                        IsPetFriendly = c.Boolean(nullable: false),
                        IsHypoallergenic = c.Boolean(nullable: false),
                        IsLegalInCity = c.Boolean(nullable: false),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shelter", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ExoticTable", "ShelterId", "dbo.Shelter");
            DropForeignKey("dbo.DomesticTable", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ExoticTable", new[] { "ShelterId" });
            DropIndex("dbo.DomesticTable", new[] { "ShelterId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ExoticTable");
            DropTable("dbo.Shelter");
            DropTable("dbo.DomesticTable");
            DropTable("dbo.AdopterTable");
        }
    }
}
