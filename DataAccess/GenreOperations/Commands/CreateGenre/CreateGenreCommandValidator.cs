using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenreOperations.Commands
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(c => c.GenreModel.Name).Must(x => x.Length > 3).WithMessage("En az 3 harfli olmalıdır.");
        }
    }
}
