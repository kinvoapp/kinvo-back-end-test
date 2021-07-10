using System.Threading.Tasks;

namespace Aliquota.Domain.Contracts.Repositories {
    public interface IContext {
        Task SaveChangesAsync();
    }
}