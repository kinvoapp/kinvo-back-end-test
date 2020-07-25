using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Interfaces
{
    public interface Iclientservice
    {
        void CreateClient(client client);
        client SearchClient(client client);
    }
}
