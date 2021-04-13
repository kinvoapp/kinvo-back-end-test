using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Aliquota.Domain.Model
{ 
    public enum OperationType
    {
        Application = 0,
        Withdraw = 1,
    }
    [Table("NewOperations")]
    public class Operation
    {
        public Operation(DateTime dateTime, string clientCPF, float amount, OperationType operationType)
        {
            this.dateTime = dateTime;
            this.clientCPF = clientCPF;
            this.amount = amount;
            this.operationType = operationType;
            profitPerMonth = .01f;
            withdrawn = false;
            this.iD = Guid.NewGuid();
        }

        public Guid iD { get; set; }
        public DateTime dateTime { get; set; }
        public string clientCPF { get; set; }
        public float amount { get; set; }
        public float profitPerMonth { get; set; }
        public OperationType operationType { get; set; }
        public bool withdrawn { get; set; }

    }
    public class OperationDB : DbContext
    {
        public OperationDB()
        {
            Database.EnsureCreated();
        }

        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                .HasKey(o => o.iD);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=.\NewOperations.db");
    }
}
