using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrailerMovieAPI.Core.Application.DTOS.Account;
using TrailerMovieAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.ViewModel.User;
using TrailerMovieAPI.Core.Application.DTOS.Actor;
using TrailerMovieAPI.Core.Application.DTOS.Director;
using TrailerMovieAPI.Core.Application.DTOS.Category;
using TrailerMovieAPI.Core.Application.DTOS.MovieDirector;
using TrailerMovieAPI.Core.Application.DTOS.MovieActor;
using TrailerMovieAPI.Core.Application.DTOS.Movie;

namespace TrailerMovieAPI.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<LoginViewModel, AuthenticationRequest>().ReverseMap();
            CreateMap<SaveUserViewModel, RegisterRequest>().ReverseMap();

            CreateMap<Actor, ActorResponse>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movies, opt => opt.Ignore());

            CreateMap<Actor, RegisterActorRequest>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movies, opt => opt.Ignore());

            CreateMap<Director, DirectorResponse>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movies, opt => opt.Ignore());

            CreateMap<Director, RegisterDirectorRequest>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movies, opt => opt.Ignore());

            CreateMap<MovieCategory,MovieCategoryResponse>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movies, opt => opt.Ignore());

            CreateMap<MovieCategory,RegisterMovieCategoryRequest>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movies, opt => opt.Ignore());

            CreateMap<MovieDirector,MovieDirectorResponse>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movie, opt => opt.Ignore())
                .ForMember(x => x.Director, opt => opt.Ignore());

            CreateMap<MovieDirector,RegisterMovieDirectorRequest>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movie, opt => opt.Ignore())
                .ForMember(x => x.Director, opt => opt.Ignore());

            CreateMap<MovieActor,MovieActorResponse>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movie, opt => opt.Ignore())
                .ForMember(x => x.Actor, opt => opt.Ignore());

            CreateMap<MovieActor,RegisterMovieActorRequest>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Movie, opt => opt.Ignore())
                .ForMember(x => x.Actor, opt => opt.Ignore());

            CreateMap<Movie, MovieResponse>()
                .ForMember(x=>x.Directors,opt=>opt.MapFrom(x=>x.Directors.Select(x=>x.Director).ToList()))
                .ForMember(x=>x.Actors,opt=>opt.MapFrom(x=>x.Actors.Select(x=>x.Actor).ToList()))
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore());

            CreateMap<Movie, RegisterMovieRequest>()
                .ForMember(x=>x.DirectorIds,opt=>opt.Ignore())
                .ForMember(x=>x.ActorIds,opt=>opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Directors, opt => opt.Ignore())
                .ForMember(x => x.Actors, opt => opt.Ignore());


        }
    }
}
