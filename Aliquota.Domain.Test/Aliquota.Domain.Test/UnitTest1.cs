using System;
using Xunit;
using Aliquota.Domain.Controller;

namespace Aliquota.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void IRTest1()
        {
            ProgramController controller = new ProgramController();
            controller.Apply("11111111111", "50", "01/01/2019");
            float[] f = controller.Withdraw("11111111111", "01/01/2020");
            float IRPercentage = (f[1] / f[2]) * 100;
            Assert.Equal(22.5f, Math.Round(IRPercentage, 3));
        }

        [Fact]
        public void IRTest2()
        {
            ProgramController controller = new ProgramController();
            controller.Apply("11111111111", "1000", "01/01/2019");
            float[] f = controller.Withdraw("11111111111", "01/01/2021");
            float IRPercentage = (f[1] / f[2]) * 100;
            Assert.Equal(18.5f, Math.Round(IRPercentage, 3));
        }

        [Fact]
        public void IRTest3()
        {
            ProgramController controller = new ProgramController();
            controller.Apply("11111111111", "1000", "01/01/2019");
            float[] f = controller.Withdraw("11111111111", "01/01/2023");
            float IRPercentage = (f[1] / f[2]) *100;
            Assert.Equal(15f, Math.Round(IRPercentage, 3));
        }

        [Fact]
        public void NotZeroOrLess()
        {
            ProgramController controller = new ProgramController();
            Assert.Null(controller.Apply("11111111111", "0", "01/01/2019"));
            Assert.Null(controller.Apply("11111111111", "-10", "01/01/2019"));
        }

        [Fact]
        public void NoWithdrawBeforeApplication()
        {
            ProgramController controller = new ProgramController();
            controller.Apply("11111111111", "50", "02/01/2019");
            Assert.Null(controller.Withdraw("11111111111", "01/01/2019"));
        }
    }
}
