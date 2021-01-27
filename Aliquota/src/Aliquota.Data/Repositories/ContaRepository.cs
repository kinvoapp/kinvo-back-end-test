using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Domain.Models.Validations;
using Aliquota.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Infra.Data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly AliquotaContext _context;
        public ContaRepository(AliquotaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Conta>> ListContasAsync()
        {
            return await _context.Applications.AsNoTracking().ToListAsync();
        }

        public async Task<Conta> GetContaByIdAsync(Guid id)
        {
            return await _context.Applications.AsNoTracking().FirstAsync(e => e.Id == id);
        }

        public async Task<Conta> UpdateConta(Guid id)
        {
            var app = await _context.Applications.FirstAsync(p => p.Id == id);
            app.DtResgate = DateTime.UtcNow;
            app.Ativo = false;
            ContaValidation validator = new ContaValidation();

            var result = await validator.ValidateAsync(app);
            if (result.IsValid)
            {
                _context.Applications.Update(app);
                await _context.SaveChangesAsync();
            }

            return app;
        }

    }
}
