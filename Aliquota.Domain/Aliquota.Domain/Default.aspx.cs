using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aliquota.Domain
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
            var Ap1 = Convert.ToDouble(TbAp1.Text);
            var Ap2 = Convert.ToDouble(TbAp2.Text);
            var Meses = Convert.ToInt32(TbMsI.Text);
            double Juros = 0.22;
            double i = Juros / 100;
            var mp = Math.Pow((1+i), Meses);
            var FV = (Ap2 * (mp - 1)) / i;
            var Total = FV + (Ap1 * mp);
            var Resg = Convert.ToString(Math.Round(Total, 2));
            var ResgIR = "";
            double IR = 0;

            if (Meses <= 12) {
                IR = 22.5 / 100;
                LbPIR.Text = " 22,5%";
                ResgIR = Convert.ToString(Math.Round(Total-(Total*IR), 2));
            }
            if (Meses > 12)
            {
                IR = 18.5 / 100;
                LbPIR.Text = " 18,5%";
                ResgIR = Convert.ToString(Math.Round(Total - (Total * IR), 2));
            }
            if (Meses >= 24)
            {
                IR = 15 / 100;
                LbPIR.Text = " 15%";
                ResgIR = Convert.ToString(Math.Round(Total - (Total * IR), 2));
            }

            LbResgate.Text = " R$ " + Resg;
            LbResgateIR.Text = " R$ " + ResgIR;
        }

    }
}
