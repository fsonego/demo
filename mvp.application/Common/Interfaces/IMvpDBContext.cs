using Microsoft.EntityFrameworkCore;
using mvp.domain.Entities;


namespace mvp.application.Common.Interfaces
{

    public interface IMvpDBContext
    {
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
