namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Careers", new[] { "Title" });
            DropIndex("dbo.Countries", new[] { "Title" });
            DropIndex("dbo.Genres", new[] { "Title" });
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        MovieId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ValueOfRating = c.Byte(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MovieId, t.UserId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.MovieId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.MovieId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            AddColumn("dbo.Movies", "ImagePath", c => c.String());
            AlterColumn("dbo.Careers", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "PremiereDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Countries", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Genres", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Careers", "Title", unique: true);
            CreateIndex("dbo.Countries", "Title", unique: true);
            CreateIndex("dbo.Genres", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserComments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserComments", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "MovieId", "dbo.Movies");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserComments", new[] { "User_Id" });
            DropIndex("dbo.UserComments", new[] { "MovieId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Ratings", new[] { "User_Id" });
            DropIndex("dbo.Ratings", new[] { "MovieId" });
            DropIndex("dbo.Genres", new[] { "Title" });
            DropIndex("dbo.Countries", new[] { "Title" });
            DropIndex("dbo.Careers", new[] { "Title" });
            AlterColumn("dbo.People", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Genres", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Countries", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Movies", "PremiereDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Careers", "Title", c => c.String(maxLength: 100));
            DropColumn("dbo.Movies", "ImagePath");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserComments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Ratings");
            CreateIndex("dbo.Genres", "Title", unique: true);
            CreateIndex("dbo.Countries", "Title", unique: true);
            CreateIndex("dbo.Careers", "Title", unique: true);
        }
    }
}
