using System.Collections.Generic;

namespace Aliquota.Domain.Models.ViewsModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
