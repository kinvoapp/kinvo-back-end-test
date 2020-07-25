using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities
{
    public class application
    {
		public int id { get; set; }
		public int idclient { get; set; }
		public client client { get; set; }
		public int idproductfinancial { get; set; }
		public productfinancial productfinancial { get; set; }
		public DateTime dateapplication { get; set; }
		public decimal valueapplication { get; set; }
		public DateTime daterescue { get; set; }
		public decimal valuegrossrescue { get; set; }
		public decimal taxIRrescue { get; set; }
		public decimal valueliquidrescue { get; set; }
	}
}
