using Application.Domain;
using Application.Domain.Membership;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Data.Repository
{
    public interface IUserRepository: IRepository<User>
    {

        Task<int> GetUserIdAsync(User user, CancellationToken cancellationToken);

        Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken);

        Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken);

        Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken);

        Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken);

        Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken);

        Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken);

        Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken);

        Task<User> FindByIdAsync(int userId, CancellationToken cancellationToken);

        Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);

        Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken);

        Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken);

        Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken);       

    }
}
