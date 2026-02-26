using Volunteer.Domain.Entities.Users;

namespace Volunteer.Application.Common.Interfaces;

public interface IUsersRepositories
{
    public void Add(User user);
    
    public void Update(User user);
    
    Task<User> GetByIdAsync(Guid userId,CancellationToken cancellationToken = default);
}