using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using mvp.application.Common.Interfaces;
using mvp.domain.Entities;

namespace mvp.application.Users.Queries.GetAllUsersByActive;

public record GetAllUsersQuery : IRequest<List<UserDto>> {
    public bool? IsActive { get; set; }
}
public class GetAllUserByActiveQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>> 
{
    private readonly IMvpDBContext _context;
    private readonly IMapper _mapper;

    public GetAllUserByActiveQueryHandler(IMvpDBContext context , IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Users
                        .AsNoTracking()
                        .Where(p => p.Active == request.IsActive)
                        .ProjectTo<UserDto>(_mapper.ConfigurationProvider)                        
                        .ToListAsync(cancellationToken);
        
        return result;
    }

}

