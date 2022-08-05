using TrailerMovieAPI.Core.Application.DTOS.Account;
using TrailerMovieAPI.Core.Application.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailerMovieAPI.Core.Application.Interfaces.Services
{
    public interface IUserServices
    {
        Task<AuthenticationResponse> LoginAsync(LoginViewModel model);
        Task<RegisterResponse> RegisterAdministratorAsync(SaveUserViewModel model);
        Task LogOutAsync();
    }
}
