using Aliquota.Domain.Entity;

namespace Aliquota.Domain.Interface
{
    public interface IApplicationRepository
    {
        void Create(Share share);
        Share WithDrawShareApplication(string fantasyName);
    }
}
