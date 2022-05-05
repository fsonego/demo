using MediatR;
using mvp.application.Common.Exceptions;
using mvp.application.Common.Interfaces;
using mvp.application.Users.Queries.GetAllUsersByActive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp.application.Users.Commands.CreateUser;

public record DeleteUserCommand : IRequest { 
    public Guid Id { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{

    private readonly IMvpDBContext context;

    public DeleteUserCommandHandler(IMvpDBContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = context.Users.SingleOrDefault(p => p.UserId == request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserDto), request.Id);
        }

        context.Users.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}