using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Domain.Common;

namespace TrailerMovieAPI.Core.Domain.Entities
{
    public class Director : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<MovieDirector> Movies { get; set; }

    }
}
