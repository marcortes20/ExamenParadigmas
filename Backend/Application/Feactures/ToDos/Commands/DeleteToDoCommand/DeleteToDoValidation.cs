using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feactures.ToDos.Commands.DeleteToDoCommand
{
    public class DeleteToDoValidation : AbstractValidator<DeleteToDoCommand>
    {
        public DeleteToDoValidation() {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("Id must be a number");
        }
    }
}
