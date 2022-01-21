using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AuthorOperations.Command
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthorCommand>
    {
        readonly DateTime d = new DateTime(2000,1,1);
        public CreateAuthorValidator()
        {
            RuleFor(c => c.Model.FirstName).MinimumLength(3);
            RuleFor(c => c.Model.LastName).MinimumLength(3);
            RuleFor(c => c.Model.BirthOfDate).LessThan(d);
        }
    }
}
