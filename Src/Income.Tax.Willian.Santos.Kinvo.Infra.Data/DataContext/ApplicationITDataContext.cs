
using Income.Tax.Willian.Santos.Kinvo.Domain.DTOs;
using Income.Tax.Willian.Santos.Kinvo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Infra.Data.DataContext
{
    public class ApplicationITDataContext : DbContext
    {
        public ApplicationITDataContext(DbContextOptions<ApplicationITDataContext> options)
            : base(options) { }

        public DbSet<ApplicationIT> Applications { get; set; }

        internal Task<List<ApplicationIT>> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
