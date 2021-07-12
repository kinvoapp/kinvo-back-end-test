using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;

namespace Aliquota.WebApp.DataInitializers
{
    public class UserInitializer
    {
        private readonly AppDbContext context;

        public UserInitializer(AppDbContext context)
        {
            this.context = context;
        }

        public void EnsureUsersExistAndRecreate(List<User> users)
        {
            foreach(var user in users) {
                var exisingUser = context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                if(exisingUser != null)
                {
                    context.Users.Remove(exisingUser);

                    var portfolio = context.Portfolios.Where(p => p.OwnerId == exisingUser.Id).FirstOrDefault();

                    if (portfolio != null) {
                        context.Portfolios.Remove(portfolio);
                    }
                }
            }

            context.Users.AddRange(users);
            context.SaveChangesAsync();
        }
    }
}