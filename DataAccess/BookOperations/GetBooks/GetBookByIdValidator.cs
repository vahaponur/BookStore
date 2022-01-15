using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookOperations.GetBooks
{
    public class GetBookByIdValidator:AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
        }
    }
}
