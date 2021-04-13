using Aliquota.Domain.DTO;

namespace Aliquota.API.Models.Response
{
    public class ApplyResponse
    {
        public string ApplicationCode { get; set; }
        public static explicit operator ApplyResponse(ApplicationDTO application)
        {
            return new ApplyResponse() { ApplicationCode = application.ApplicationCode };
        }
    }
}