using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BookOperations.UpdateBook
{
    public class UpdateBookValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {
            
            RuleFor(c => c.Model.GenreId).GreaterThan(0);
            RuleFor(c => c.Model.PageCount).GreaterThan(0);
            RuleFor(c => c.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(c => c.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(c => c.BookId).GreaterThan(0);
        }
    }
}
