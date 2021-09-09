using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.Repositories
{
    public interface IInvestimentoRepository
    {
        Investimento Add(Investimento investimento);
        IList<Investimento> GetAll();
        Investimento GetById(int investimentoId);
        Investimento Update(int investimentoId, Investimento investimento);
        void Recue(int investimentoId);
        void Delete(int id);
    }

    public class InvestimentoRepository : BaseRepository<Investimento>, IInvestimentoRepository
    {
        public InvestimentoRepository(AliquotaContext context) : base(context)
        {
        }

        public Investimento Add(Investimento investimento)
        {
            this.dbSets.Add(investimento);
            SaveChanges();
            return investimento;
        }

        public IList<Investimento> GetAll()
            => this.dbSets
                      .Include(i => i.Produto)
                      .ToList();

        public Investimento GetById(int investimentoId)
            => this.dbSets
                      .Include(i => i.Produto)
                      .Where(i => i.Id == investimentoId)
                      .SingleOrDefault();
        
        public Investimento Update(int investimentoId, Investimento investimento)
        {
            var investimentoDB = GetById(investimentoId);
            investimentoDB.EditInvestimento(investimento);

            SaveChanges();
            
            return investimentoDB;
        }

        public void Recue(int investimentoId)
        {
            var investimentoDB = GetById(investimentoId);
            var rendimento = new RendimentoInvest(investimentoDB);

            investimentoDB.RescueInvestimento(rendimento);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var investimentoDB = GetById(id);
            this.dbSets.Remove(investimentoDB);
            SaveChanges();
        }

        private void SaveChanges() => this.context.SaveChanges();

    }
}
