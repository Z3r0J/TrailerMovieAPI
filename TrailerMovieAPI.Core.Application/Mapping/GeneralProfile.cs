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

namespace TrailerMovieAPI.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<LoginViewModel, AuthenticationRequest>().ReverseMap();
            CreateMap<SaveUserViewModel, RegisterRequest>().ReverseMap();

        }
    }
}
