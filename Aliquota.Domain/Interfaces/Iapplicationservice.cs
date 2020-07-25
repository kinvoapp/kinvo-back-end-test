using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Interfaces
{
    public interface Iapplicationservice
    {
        void CreateApplication(application application);
        void RescueApplication(application application);
    }
}
