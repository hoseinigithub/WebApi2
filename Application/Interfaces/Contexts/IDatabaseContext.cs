using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Application.Interfaces.Contexts;

public interface IDatabaseContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<UserInRole> UserInRoles { get; set; }

    int SaveChanges(bool acceptAllChangesOnSuccess);

    int SaveChanges();

    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}