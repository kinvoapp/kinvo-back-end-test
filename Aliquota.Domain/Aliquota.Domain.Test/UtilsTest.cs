using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Aliquota.Domain.Utils;

namespace Aliquota.Domain.Test
{
    public class UtilsTest
    {
        [Fact]
        public void CalculaDiferencaDatasTest()
        {            
            var valorEsperado = new DiferencaDatas { dias = 406, meses = 13, anos = 1 }; ;
            var difDatas = CalculaDiferencaDatas(new DateTime(2021, 5, 20), new DateTime(2020, 4, 9));

            Assert.Equal(valorEsperado, difDatas);
        }
    }
}
