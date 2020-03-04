﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.CrossCuting
{
   public static class Utils
    {
        /// <summary>
        ///     Obtem valor monetário
        ///     <para>Resultado no valor correspondente ao valor com base em sua porcentagem</para>
        /// </summary>
        /// <param name="valor">Valor</param>
        /// <param name="porcentual">Taxa porcentual, expressa pela divisão por 100</param>
        /// <returns></returns>
        public static decimal ObterValorBasePorcentual(decimal valor, decimal porcentual)
        {
            return valor == 0 ? valor : decimal.Round(valor * (porcentual), 2);
        }

        /// <summary>
        ///     Arredondamento padrão, 2 casas decimais
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static decimal Arredondar(this decimal valor)
        {
            return valor == 0 ? 0 : decimal.Round(valor, 2, MidpointRounding.ToEven);
        }

        /// <summary>
        /// Trunca valores decimais
        /// </summary>
        /// <param name="valor">Valor decimal</param>
        /// <param name="precisao">Precisão de casas decimais</param>
        /// <returns></returns>
        public static decimal TruncateDecimal(this decimal valor, int precisao)
        {
            decimal step = (decimal)Math.Pow(10, precisao);
            decimal tmp = Math.Truncate(step * valor);
            return tmp / step;
        }

        /// <summary>
        ///     Arredondamento customizado
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="casadecimal">Quantidade de casas decimais</param>
        /// <returns></returns>
        public static decimal Arredondar(this decimal valor, int casadecimal)
        {
            return valor == 0 ? 0 : decimal.Round(valor, casadecimal, MidpointRounding.ToEven);
        }


    }
}
