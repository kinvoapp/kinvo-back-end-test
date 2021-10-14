using System;
using Aliquota.Domain.Entities.Models;


namespace Aliquota.Domain.UseCases.Plugin.Interfaces
{
	public interface ITaxer
	{
		public decimal Tax(decimal amount, DateTime dateTime);
        decimal GetTaxForDate(DateTime dateTime);
    }
}
