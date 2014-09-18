using System.Data.Entity.Migrations;
using MovieSearch.Data.DAL.Context;

namespace MovieSearch.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MovieSearch.Data.MoviesContext";
        }

        protected override void Seed(MoviesDbContext context)
        {
            //var countries = new List<Country>
            //{
            //    new Country { Id = Guid.NewGuid(), Title = "USA" },
            //    new Country { Id = Guid.NewGuid(), Title = "England"  },
            //    new Country { Id = Guid.NewGuid(), Title = "Canada" },
            //    new Country { Id = Guid.NewGuid(), Title = "Italiy"  },
            //    new Country { Id = Guid.NewGuid(), Title = "German"  },
            //    new Country { Id = Guid.NewGuid(), Title = "France" },
            //};
            //countries.ForEach(s => context.Countries.AddOrUpdate(p => p.Title, s));
            //context.SaveChanges();

            //var movies = new List<Movie>
            //{
            //    new Movie
            //    {
            //        Id = Guid.NewGuid(), 
            //        Title = "Fast and Furious 6", 
            //        PremiereDate = DateTime.Parse("2001-09-01"),
            //        Desctiption = "Fast and Furious 6 Desctiption",
            //        ImdbTitle = "1",
            //        CountryId = countries.Single(c => c.Title == "USA").Id
            //    },
            //    new Movie 
            //    { 
            //        Id = Guid.NewGuid(), 
            //        Title = "The Kings of Summer",
            //        PremiereDate = DateTime.Parse("2002-01-01"),
            //        Desctiption = "The Kings of Summer Desctiption",
            //        ImdbTitle = "2",
            //        CountryId = countries.Single(c => c.Title == "USA").Id
            //    },
            //    new Movie
            //    {
            //        Id = Guid.NewGuid(), 
            //        Title = "Captain Phillips",
            //        PremiereDate = DateTime.Parse("2003-09-05"),
            //        Desctiption = "Captain Phillips Desctiption",
            //        ImdbTitle = "3",
            //        CountryId = countries.Single(c => c.Title == "USA").Id
            //    },
            //    new Movie
            //    {
            //        Id = Guid.NewGuid(),
            //        Title = "Before Midnight",
            //        PremiereDate = DateTime.Parse("2004-04-01"),
            //        Desctiption = "Before Midnight Desctiption",
            //        ImdbTitle = "4",
            //        CountryId = countries.Single(c => c.Title == "USA").Id
            //    },
            //    new Movie
            //    {
            //        Id = Guid.NewGuid(),
            //        Title = "20 Feet From Stardom",
            //        PremiereDate = DateTime.Parse("2001-05-01"),
            //        Desctiption = "20 Feet From Stardom Desctiption",
            //        ImdbTitle = "5",
            //        CountryId = countries.Single(c => c.Title == "USA").Id
            //    },
            //    new Movie
            //    {
            //        Id = Guid.NewGuid(), 
            //        Title = "Nebraska",
            //        PremiereDate = DateTime.Parse("2002-09-01"),
            //        Desctiption = "Nebraska Desctiption",
            //        ImdbTitle = "6",
            //        CountryId = countries.Single(c => c.Title == "Canada").Id
            //    },
            //    new Movie
            //    {
            //        Id = Guid.NewGuid(), 
            //        Title = "Fruitvale Station",
            //        PremiereDate = DateTime.Parse("2003-09-03"),
            //        Desctiption = "Fruitvale Station Desctiption",
            //        ImdbTitle = "7",
            //        CountryId = countries.Single(c => c.Title == "USA").Id
            //    },
            //    new Movie
            //    {
            //        Id = Guid.NewGuid(), 
            //        Title = "Rush",
            //        PremiereDate = DateTime.Parse("2000-09-04"),
            //        Desctiption = "Rush Desctiption",
            //        ImdbTitle = "8",
            //        CountryId = countries.Single(c => c.Title == "England").Id
            //    },
            //    new Movie
            //    {
            //        Id = Guid.NewGuid(), 
            //        Title = "Blue Jasmine",
            //        PremiereDate = DateTime.Parse("2005-09-07"),
            //        Desctiption = "Blue Jasmine Desctiption",
            //        ImdbTitle = "9",
            //        CountryId = countries.Single(c => c.Title == "USA").Id
            //    }
            //};
            //movies.ForEach(s => context.Movies.AddOrUpdate(p => p.ImdbTitle, s));
            //context.SaveChanges();

            //var careers = new List<Career>
            //{
            //    new Career { Id = Guid.NewGuid(), Title = "Actor" },
            //    new Career { Id = Guid.NewGuid(), Title = "Director"  },
            //    new Career { Id = Guid.NewGuid(), Title = "Producer" },
            //    new Career { Id = Guid.NewGuid(), Title = "Executive Producer"  },
            //    new Career { Id = Guid.NewGuid(), Title = "Script Supervisor"  },
            //    new Career { Id = Guid.NewGuid(), Title = "Camera Operator" },
            //    new Career { Id = Guid.NewGuid(), Title = "Art Director"  },
            //    new Career { Id = Guid.NewGuid(), Title = "Costume designer"  },
            //    new Career { Id = Guid.NewGuid(), Title = "Sound Designer"  }
            //};
            //careers.ForEach(s => context.Careers.AddOrUpdate(p => p.Title, s));
            //context.SaveChanges();

            //var peoples = new List<People>
            //{
            //    new People
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "Brad",
            //        LastName = "Pitt",
            //        BirthPlace = "New York, USA",
            //        BirthDay = DateTime.Parse("1971-09-01")
            //    },
            //    new People
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "Jack",
            //        LastName = "Nicholson",
            //        BirthPlace = "Los Angeles, USA",
            //        BirthDay = DateTime.Parse("1973-09-03")
            //    },
            //    new People
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "Ralph",
            //        LastName = "Fiennes",
            //        BirthPlace = "New York, USA",
            //        BirthDay = DateTime.Parse("1961-09-02")
            //    },
            //    new People
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "Daniel",
            //        LastName = "Day-Lewis",
            //        BirthPlace = "Chicago, USA",
            //        BirthDay = DateTime.Parse("1980-09-04")
            //    },
            //    new People
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "Robert",
            //        LastName = "De Niro",
            //        BirthPlace = "San Diego, USA",
            //        BirthDay = DateTime.Parse("1967-09-05")
            //    },
            //    new People
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "Al",
            //        LastName = "Pacino",
            //        BirthPlace = "Austin, USA",
            //        BirthDay = DateTime.Parse("1978-09-06")
            //    },
            //    new People
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "Dustin",
            //        LastName = "Hoffman",
            //        BirthPlace = "San Francisco,  USA",
            //        BirthDay = DateTime.Parse("1960-08-11")
            //    },
            //};

            //peoples.ForEach(s => context.Peoples.AddOrUpdate(s));
            //context.SaveChanges();

            //var castAndCrews = new List<CastAndCrew>
            //{
            //    new CastAndCrew { 
            //        MovieId = movies.Single(m => m.Title == "Fast and Furious 6").Id, 
            //        PeopleId = peoples.Single(p => p.LastName == "Pitt" ).Id, 
            //        CareerId = careers.Single(c => c.Title == "Actor").Id
            //    },
            //                     new CastAndCrew { 
            //        MovieId = movies.Single(m => m.Title == "Fast and Furious 6").Id, 
            //        PeopleId = peoples.Single(p => p.LastName == "Nicholson" ).Id, 
            //        CareerId = careers.Single(c => c.Title == "Actor").Id
            //    },                          
            //    new CastAndCrew { 
            //        MovieId = movies.Single(m => m.Title == "Before Midnight").Id, 
            //        PeopleId = peoples.Single(p => p.LastName == "Fiennes" ).Id, 
            //        CareerId = careers.Single(c => c.Title == "Actor").Id
            //    },
            //    new CastAndCrew { 
            //        MovieId = movies.Single(m => m.Title == "Before Midnight").Id, 
            //        PeopleId = peoples.Single(p => p.LastName == "Day-Lewis" ).Id, 
            //        CareerId = careers.Single(c => c.Title == "Actor").Id
            //    },
            //    new CastAndCrew { 
            //        MovieId = movies.Single(m => m.Title == "Before Midnight").Id, 
            //        PeopleId = peoples.Single(p => p.LastName == "De Niro" ).Id, 
            //        CareerId = careers.Single(c => c.Title == "Director").Id
            //    },
            //     new CastAndCrew { 
            //        MovieId = movies.Single(m => m.Title == "Fast and Furious 6").Id, 
            //        PeopleId = peoples.Single(p => p.LastName == "Pacino" ).Id, 
            //        CareerId = careers.Single(c => c.Title == "Director").Id
            //    },
            //    new CastAndCrew { 
            //        MovieId = movies.Single(m => m.Title == "20 Feet From Stardom").Id, 
            //        PeopleId = peoples.Single(p => p.LastName == "Pitt" ).Id, 
            //        CareerId = careers.Single(c => c.Title == "Director").Id
            //    },
            //    new CastAndCrew { 
            //        MovieId = movies.Single(m => m.Title == "Blue Jasmine").Id, 
            //        PeopleId = peoples.Single(p => p.LastName == "Hoffman" ).Id, 
            //        CareerId = careers.Single(c => c.Title == "Director").Id
            //    }
            //};

            //foreach (CastAndCrew e in castAndCrews)
            //{
            //    var castAndCrewInDataBase = context.CastAndCrews.SingleOrDefault(
            //        s => s.Movie.Id == e.MovieId &&
            //             s.People.Id == e.PeopleId &&
            //             s.Career.Id == e.CareerId);
            //    if (castAndCrewInDataBase == null)
            //    {
            //        context.CastAndCrews.Add(e);
            //    }
            //}
            //context.SaveChanges();
        }
    }
}
