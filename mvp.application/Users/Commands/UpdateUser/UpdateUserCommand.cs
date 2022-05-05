using AutoMapper;
using MediatR;
using mvp.application.Common.Exceptions;
using mvp.application.Common.Interfaces;
using mvp.application.Users.Queries.GetAllUsersByActive;
using mvp.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp.application.Users.Commands.CreateUser;
public record UpdateUserCommand(UserDto userDto) : IRequest { }

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand> {

    private readonly IMvpDBContext context;

    public UpdateUserCommandHandler(IMvpDBContext context)
    {
        this.context = context;        
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = context.Users.SingleOrDefault(p => p.UserId == request.userDto.UserId);
            
        if (entity == null)
        {
            throw new NotFoundException(nameof(UserDto), request.userDto.UserId);
        }

        entity.UserName = request.userDto.UserName;
        entity.BirthDate = request.userDto.BirthDate;
        entity.Active = request.userDto.Active;        

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

