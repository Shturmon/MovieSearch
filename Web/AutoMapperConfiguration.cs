using AutoMapper;
using DAL.Models;
using Web.Models;

namespace Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Genre, GenreViewModel>();
            Mapper.CreateMap<GenreViewModel, Genre>();

            Mapper.CreateMap<Country, CountryViewModel>();
            Mapper.CreateMap<CountryViewModel, Country>();

            Mapper.CreateMap<Career, CareerViewModel>();
            Mapper.CreateMap<CareerViewModel, Career>();

            Mapper.CreateMap<Movie, MovieViewModel>()
                .ForMember(m => m.GenreList, option => option.Ignore())
                .ForMember(m => m.ActorsList, option => option.Ignore())
                .ForMember(m => m.Directors, option => option.Ignore())
                .ForMember(m => m.Countries, option => option.Ignore());
            Mapper.CreateMap<MovieViewModel, Movie>()
                .ForSourceMember(m => m.ActorsList, option => option.Ignore())
                .ForSourceMember(m => m.GenreList, option => option.Ignore())
                .ForSourceMember(m => m.Countries, option => option.Ignore())
                .ForSourceMember(m => m.Directors, option => option.Ignore());

            Mapper.CreateMap<Movie, Movie>()
                .ForMember(m => m.Country, option => option.Ignore())
                .ForMember(m => m.CastAndCrews, option => option.Ignore())
                .ForMember(m => m.UserComments, option => option.Ignore())
                .ForMember(m => m.Ratings, option => option.Ignore());
            Mapper.CreateMap<Rating, Rating>();

            Mapper.CreateMap<UserComment, UserCommentViewModel>();
            Mapper.CreateMap<UserCommentViewModel, UserComment>();

            Mapper.CreateMap<People, PeopleViewModel>();
            Mapper.CreateMap<PeopleViewModel, People>();
        }
    }
}