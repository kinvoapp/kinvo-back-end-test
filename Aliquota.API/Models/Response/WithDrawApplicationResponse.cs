using Aliquota.Core.DTO;

namespace Aliquota.API.Models.Response
{
    public class WithDrawApplicationResponse
    {
        /// <summary>
        /// Fictional name
        /// </summary>
        public string FantasyName { get; set; }

        /// <summary>
        /// Processed value(tax already paid)
        /// </summary>
        public decimal Value { get; set; }

        public static explicit operator WithDrawApplicationResponse(WithDrawApplicationDto withDrawApplicationDto) =>
            new WithDrawApplicationResponse()
            {
                FantasyName = withDrawApplicationDto.FantasyName,
                Value = withDrawApplicationDto.Value
            };
    }
}
