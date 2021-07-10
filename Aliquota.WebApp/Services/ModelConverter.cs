using Aliquota.Domain.Entities;
using Aliquota.WebApp.Models;

namespace Aliquota.WebApp.Services {
    public class ModelConverter {
        public UserModel ToModel(User user){
            return new UserModel {
                Email = user.Email,
                FullName = user.FullName,
            };
        }
    }
}