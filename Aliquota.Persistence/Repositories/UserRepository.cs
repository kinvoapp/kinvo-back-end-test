using System.Linq;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistence.Repositories {
    public class UserRepository : IUserRepository
    {
        public UserRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; set; }
        public IQueryable<User> Users 
            => Context.Users.Include(u => u.Portfolio)
                            .ThenInclude(p => p.Investments);

        public void Add(User user)
        {
            Context.Users.Add(user);
        }
    }
}