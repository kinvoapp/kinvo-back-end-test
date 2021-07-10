using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Contracts.Repositories {
    public interface IUserRepository {
        void Add(User user);
    }
}