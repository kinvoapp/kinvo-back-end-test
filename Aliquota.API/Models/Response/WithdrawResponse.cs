using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Aliquota.Api.Models.Response.Convert;
using Aliquota.Domain.DTO;


namespace Aliquota.API.Models.Response
{
    public class WithdrawResponse
    {
        public string ApplicationCode { get; set; }
        
        [DataType(DataType.Date)]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime ApplicationDate { get; set; }

        public string ApplicationValue { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime? WithdrawDate { get; set; }

        public string WithdrawValue { get; set; }

        public static explicit operator WithdrawResponse(ApplicationDTO application)
        {
            return new WithdrawResponse() { 
                ApplicationCode = application.ApplicationCode, 
                ApplicationDate = application.ApplicationDate,
                ApplicationValue = application.ApplicationValue.ToString("C"),
                WithdrawDate = application.WithdrawDate,
                WithdrawValue = application.WithdrawValue.ToString("C"),
                };
        }

    }
}