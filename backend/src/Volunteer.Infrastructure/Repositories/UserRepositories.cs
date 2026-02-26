using Microsoft.EntityFrameworkCore;
using Volunteer.Application.Common.Interfaces;
using Volunteer.Domain.Entities.Users;
using Volunteer.Infrastructure.Persistence;

namespace Volunteer.Infrastructure.Repositories;

public class UserRepositories(ApplicationDbContext dbContext) : IUsersRepositories
{
    public void Add(User user)
    {
        dbContext.Users.Add(user);
    }

    public void Update(User user)
    {
        dbContext.Users.Update(user);
    }

    public void Delete(User user)
    {
        dbContext.Users.Remove(user);
    }

    public async Task<User> GetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        return await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }
}