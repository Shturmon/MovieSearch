namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.CastAndCrews",
                c => new
                    {
                        MovieId = c.Guid(nullable: false),
                        PeopleId = c.Guid(nullable: false),
                        CareerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.PeopleId, t.CareerId })
                .ForeignKey("dbo.Careers", t => t.CareerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PeopleId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.PeopleId)
                .Index(t => t.CareerId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 100),
                        PremiereDate = c.DateTime(nullable: false),
                        Desctiption = c.String(),
                        CountryId = c.Guid(nullable: false),
                        ImdbTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        BirthDay = c.DateTime(nullable: false),
                        BirthPlace = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_Id = c.Guid(nullable: false),
                        Movie_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Movie_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CastAndCrews", "PeopleId", "dbo.People");
            DropForeignKey("dbo.GenreMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Movies", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.CastAndCrews", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CastAndCrews", "CareerId", "dbo.Careers");
            DropIndex("dbo.GenreMovies", new[] { "Movie_Id" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_Id" });
            DropIndex("dbo.Genres", new[] { "Title" });
            DropIndex("dbo.Countries", new[] { "Title" });
            DropIndex("dbo.Movies", new[] { "CountryId" });
            DropIndex("dbo.CastAndCrews", new[] { "CareerId" });
            DropIndex("dbo.CastAndCrews", new[] { "PeopleId" });
            DropIndex("dbo.CastAndCrews", new[] { "MovieId" });
            DropIndex("dbo.Careers", new[] { "Title" });
            DropTable("dbo.GenreMovies");
            DropTable("dbo.People");
            DropTable("dbo.Genres");
            DropTable("dbo.Countries");
            DropTable("dbo.Movies");
            DropTable("dbo.CastAndCrews");
            DropTable("dbo.Careers");
        }
    }
}
