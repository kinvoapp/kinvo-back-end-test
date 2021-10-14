using Aliquota.Domain.UseCases.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.UseCases.ProductMovement
{
	public class Taxer : ITaxer
	{
		//Até 1 ano de aplicação: 22,5% sobre o lucro
		//De 1 a 2 anos de aplicação: 18,5% sobre o lucro
		//Acima de 2 anos de aplicação: 15% sobre o lucro
		public decimal[] taxes = { (decimal)(1-.225), (decimal)(1 - .185), (decimal)(1 - .15)};
		public int[] intervals = { 0, 1, 2 };
		public decimal GetTaxForDate(DateTime dateTime)
        {
			return taxes[GetTaxIndexOnDate(dateTime)];

		}
		private int GetTaxIndexOnDate(DateTime dateTime)
		{
			TimeSpan past = DateTime.Now - dateTime;
			int years = (int)(past.TotalDays / 360);
			int currentIndex = 0;
			for (int i = 0; i < intervals.Length; i++)
			{
				if (years < intervals[i])
					break;
				currentIndex++;
			}
			return Math.Max(currentIndex, intervals.Length-1);
		}
		public decimal Tax(decimal amount, DateTime dateTime)
		{
			return amount * GetTaxForDate(dateTime);
		}
	}
}
