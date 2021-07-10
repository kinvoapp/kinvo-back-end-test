using System.Threading.Tasks;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Contracts.Repositories {
    public interface IUserRepository {
        void Add(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}