using System;
using System.Linq;
using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface;
using Aliquota.Domain.Repository.Context;

namespace Aliquota.Domain.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AliquotContext dbcontext;
        public ApplicationRepository(AliquotContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public void Create(Share share)
        {
            dbcontext.Add(share);
            dbcontext.SaveChanges();
        }

        public Share WithDrawShareApplication(string fantasyName)
        {
            Share share = dbcontext.Shares.FirstOrDefault(s => s.FantasyName == fantasyName);
            share.WithdrawDate = DateTime.Now;
            dbcontext.SaveChanges();
            return share;
        }
    }
}
