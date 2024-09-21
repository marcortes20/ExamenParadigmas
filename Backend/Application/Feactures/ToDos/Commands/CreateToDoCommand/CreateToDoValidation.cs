using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Feactures.ToDos.Commands.CreateToDoCommand
{
    public class CreateToDoValidation : AbstractValidator<CreateToDoCommand>
    {
        public CreateToDoValidation()
        {
            RuleFor(x => x.TodoTitle).NotEmpty().NotNull().MinimumLength(5);
            RuleFor(x => x.TodoContent).NotEmpty().NotNull();
        }
    }
}
