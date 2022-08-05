using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailerMovieAPI.Core.Application.DTOS.Category
{
    public class RegisterMovieCategoryResponse
    {
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
