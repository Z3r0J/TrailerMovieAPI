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

        }
    }
}
