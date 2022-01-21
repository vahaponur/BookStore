using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailValidator:AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailValidator()
        {
            RuleFor(c => c.GenreId).GreaterThan(0);
        }
    }
}
