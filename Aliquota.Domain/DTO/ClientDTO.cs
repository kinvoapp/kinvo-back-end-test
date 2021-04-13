using Aliquota.Data.Entity;

namespace Aliquota.Domain.DTO
{
    public class ClientDTO
    {
        public long ClientId { get; set; }

        public string CPF { get; set; }
        public static explicit operator ClientDTO(Client client){
            return new ClientDTO {ClientId = client.ClientId, CPF = client.CPF};
        }
    }
}