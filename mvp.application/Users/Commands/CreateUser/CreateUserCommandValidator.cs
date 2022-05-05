using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp.application.Users.Commands.CreateUser
{
    public  class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.userDto.UserName )
                .NotEmpty().WithMessage("UserName is required.");
            
        }
    }
}
