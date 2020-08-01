using Aliquota.Domain.Entities;
using Aliquota.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Infra.Data.Context
{
    class AliquotaContextFacoty : IDesignTimeDbContextFactory<AliquotaContext>
    {
        public AliquotaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AliquotaContext>();
            optionsBuilder.UseSqlite("Data Source=./Database/aliquota.db");

            return new AliquotaContext(optionsBuilder.Options);
        }
    }
}
