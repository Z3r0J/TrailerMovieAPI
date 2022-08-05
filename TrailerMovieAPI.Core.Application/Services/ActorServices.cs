using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Actor;
using TrailerMovieAPI.Core.Application.Interfaces.Repository;
using TrailerMovieAPI.Core.Application.Interfaces.Services;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Services
{
    public class ActorServices : GenericServices<RegisterActorRequest,ActorResponse,Actor>,IActorServices
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public ActorServices(IActorRepository actorRepository, IMapper mapper) : base(actorRepository,mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }
    }
}
