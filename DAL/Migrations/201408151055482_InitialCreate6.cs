namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                {
                    MovieId = c.Guid(nullable: false),
                    ValueOfRating = c.Byte(nullable: false),
                    UserId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => new { t.MovieId, t.UserId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
        }
        
        public override void Down()
        {
            
        }
    }
}
