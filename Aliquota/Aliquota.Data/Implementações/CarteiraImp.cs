using Aliquota.Data.Context;
using Aliquota.Data.Contratos;

namespace Aliquota.Data.Implementações
{
    public class CarteiraImp : ICarteiraPersist
    {
        public readonly AliquotaContext context;
        public CarteiraImp(AliquotaContext _context)
        {
            this.context = _context;
        }
        public void Add<Carteira>(Carteira carteira)
        {
            context.Add(carteira);
        }

        public void Investir(double ValorInvestido, int id)
        {
            context.Update(ValorInvestido);
        }
    }
}
