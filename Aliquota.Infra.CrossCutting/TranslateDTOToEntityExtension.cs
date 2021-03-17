using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Entities.Financial;
using Aliquota.Domain.Entities.ValueObjects;
using System;

namespace Aliquota.Infra.CrossCutting
{
    public static class TranslateDTOToEntityExtension
    {
        public static Customer ConvertCustomerDTOToCustumer(this CustomerDTO customerDTO)
        {
            Customer customer = new Customer();

            customer.Id = customerDTO.IdCustomer;
            customer.Telephone = new Telephone() { NuTelephone = customerDTO.Telephone };
            customer.NmCustomer = customerDTO.NmCustomer;
            customer.Email = customerDTO.Email;
            customer.DtRegister = Convert.ToDateTime(customerDTO.DtRegister);

            return customer;
        }


        public static CustomerProduct ConvertCustomerProductDTOToCustomerProduct(this CustomerProductDTO customerProductDTO)
        {
            CustomerProduct customerProduct = new CustomerProduct();

            customerProduct.Customer.Id = customerProductDTO.CustomerId;
            customerProduct.Product.Id = customerProductDTO.ProductId;
            // caso seja preciso, pode ser passado o database por parâmetro e preeencher
            // os outros dados, no momento, não foi preciso

            return customerProduct;
        }


        public static MovementApplication ConvertMovementApplicationDTOToMovementApplication(this MovementApplicationDTO movementApplicationDTO)
        {
            MovementApplication movementApplication = new MovementApplication();

            movementApplication.MakeApplication(movementApplicationDTO.QtLot, movementApplicationDTO.Value, Convert.ToDateTime(movementApplicationDTO.DtRegister));


            // caso seja preciso, pode ser passado o database por parâmetro e preeencher
            // os outros dados, no momento, não foi preciso

            return movementApplication;
        }


        public static MovementRescue ConvertMovementRescueDTOToMovementRescue(this MovementRescueDTO movementRescueDTO)
        {
            MovementRescue movementRescue = new MovementRescue();

            movementRescue.DtRegister = Convert.ToDateTime(movementRescueDTO.DtRegister);
            movementRescue.DtRescue = Convert.ToDateTime(movementRescueDTO.DtRescue);
            movementRescue.Tax = new Tax() { Id = movementRescueDTO.TaxId };
            // caso seja preciso, pode ser passado o database por parâmetro e preeencher
            // os outros dados, no momento, não foi preciso

            return movementRescue;
        }
    }
}
