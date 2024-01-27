using AutoMapper;
using MovieApi.Data.Entities;
using MovieApi.Models;
using MovieApi.Services.Models;

namespace MovieApi.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<MovieDto, Movie>()
            .ForMember(des => des.Genres, options => options.MapFrom(src => string.Join(", ", src.Genres)));
        CreateMap<Movie, MovieDto>()
            .ForMember(des => des.Genres, options => options.MapFrom(src => src.Genres.Split(',', StringSplitOptions.TrimEntries)));
        CreateMap(typeof(Pagination<>), typeof(PaginationDto<>));
    }
}