namespace Aliquota.Data.Contratos
{
    public interface ICarteiraPersist
    {
        void Add<Carteira>(Carteira carteira);
        void Investir(double ValorInvestido, int id); //Entra um produto ? 
        
    }
}
