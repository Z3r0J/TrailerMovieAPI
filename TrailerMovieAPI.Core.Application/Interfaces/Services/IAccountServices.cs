using TrailerMovieAPI.Core.Application.DTOS.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrailerMovieAPI.Core.Application.Interfaces.Services
{
    public interface IAccountServices
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task LogOutAsync();
        Task<RegisterResponse> RegisterAdministratorAsync(RegisterRequest request);
    }
}