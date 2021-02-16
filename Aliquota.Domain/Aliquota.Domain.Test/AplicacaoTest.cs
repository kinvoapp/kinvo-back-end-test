using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aliquota.Domain;
using Aliquota.Domain.Shared.Models;
using Aliquota.Domain.Shared.Utils;
using System;

namespace Aliquota.Domain.Test
{
    [TestClass]
    public class AplicacaoTest
    {
        #region ConverteJurosAnoMes
        
        [TestMethod]
        public void ConverteJurosAnoMesCorreto()
        {
            bool fromCall = Utilitarios.ConverteJurosAnoMes(12) == 0.95;

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void ConverteJurosAnoMesErrado()
        {
            bool fromCall = Utilitarios.ConverteJurosAnoMes(12) == 1.0;

            Assert.IsFalse(fromCall);
        }

        #endregion

        #region CalculaRentabilidade
        [TestMethod]
        public void CalculaRentabilidadeCerto()
        {
            bool fromCall = Utilitarios.CalculaRentabilidade(100, 2.5, 12) == 102.55M;

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void CalculaRentabilidadeErrado()
        {
            bool fromCall = Utilitarios.CalculaRentabilidade(100, 2.5, 12) == 102.549M;

            Assert.IsFalse(fromCall);
        }

        #endregion

        #region VerificaDatas

        [TestMethod]
        public void VerificaDatasPrimeiraMenorQueSegunda()
        {
            DateTime primeira = DateTime.Now;
            DateTime segunda = primeira.AddDays(1);
            bool fromCall = Utilitarios.VerificaDatas(primeira, segunda);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void VerificaDatasPrimeiraMaiorQueSegunda()
        {
            DateTime segunda = DateTime.Now;
            DateTime primeira = segunda.AddDays(1);
            bool fromCall = Utilitarios.VerificaDatas(primeira, segunda);

            Assert.IsFalse(fromCall);
        }

        #endregion

        #region CalculaDias

        [TestMethod]
        public void CalculaDiasCerto()
        {
            int dias = 365;
            DateTime inicio = DateTime.Now;
            DateTime final = inicio.AddDays(dias);
            bool fromCall = Utilitarios.CalculaDias(inicio, final) == dias;

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void CalculaDiasErrado()
        {
            int dias = 365;
            DateTime inicio = DateTime.Now;
            DateTime final = inicio.AddDays(dias);
            bool fromCall = Utilitarios.CalculaDias(inicio, final) == 30;

            Assert.IsFalse(fromCall);
        }

        #endregion

        #region CalculaAliquota
        
        [TestMethod]
        public void CalculaAliquotaCerto() 
        {
            bool fromCall = Utilitarios.CalculaAliquota(365) == 22.5;

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void CalculaAliquotaErrado() 
        {
            bool fromCall = Utilitarios.CalculaAliquota(365) == 18.5;

            Assert.IsFalse(fromCall);
        }

        #endregion

        #region ImpostoDeRenda

        [TestMethod]
        public void ImpostoDeRendaCerto()
        {
            bool fromCall = Utilitarios.ImpostoDeRenda(1000, 18.5) == 185.0M;

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void ImpostoDeRendaErrado()
        {
            bool fromCall = Utilitarios.ImpostoDeRenda(1000, 18.5) == 150.0M;

            Assert.IsFalse(fromCall);
        }

        #endregion
    }
}
