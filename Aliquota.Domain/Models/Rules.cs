using System;

namespace Aliquota.Domain.Models
{
    public class Rules
    {
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationRescue { get; set; }
        public double ApplicationValue { get; set; }
        public double GrossValue { get; set; }

        public double Income = 0.1;

        public double Ir { get; set; }
        public double Profit { get; set; }

        public double LiquidValue { get; set; }

        public Rescue Rescue(Application application)
        {
            ApplicationDate = application.ApplicationDate;
            ApplicationRescue = application.ApplicationRescue;
            ApplicationValue = application.ApplicationValue;


            TimeSpan time = ApplicationRescue - ApplicationDate;

            int interval = time.Days;

            //Calculo de quantidade de anos completos(365 dias)
            //para aplicações acima de 1 ano continuarem mantendo consistência.
            //Ou seja, o valor de rendimento é acrescido ao valor aplicado
            //a cada ano completado
            int applicationTime = (int)interval / 365;


            if (interval <= 365)
            {
                Profit = Math.Round(application.ApplicationValue * Income, 2);
                GrossValue = Math.Round(application.ApplicationValue + Profit, 2);
                Ir = Math.Round(Profit * 22.5 / 100 , 2);
                LiquidValue = Math.Round(GrossValue - Ir, 2);

            }
            else if (interval > 365 && interval <= 730)
            {

                Profit = Math.Round(application.ApplicationValue * (Income * applicationTime) , 2);
                GrossValue = Math.Round(application.ApplicationValue + Profit, 2);
                Ir = Math.Round(Profit * 18.5 / 100 , 2);
                LiquidValue = Math.Round(GrossValue - Ir , 2);

            }
            else
            {

                Profit =  Math.Round(application.ApplicationValue * (Income * applicationTime), 2);
                GrossValue = Math.Round(application.ApplicationValue + Profit, 2);
                Ir = Math.Round(Profit * 15 / 100 , 2);
                LiquidValue = Math.Round(GrossValue - Ir, 2);
            }

            Rescue rescue = new();
            rescue.ApplicationDate = ApplicationDate;
            rescue.ApplicationRescue = ApplicationRescue;
            rescue.ApplicationValue = ApplicationValue;
            rescue.GrossValue = GrossValue;
            rescue.Income = Income * 100 + "%";
            rescue.Ir = Ir;
            rescue.Profit = Profit;
            rescue.LiquidValue = LiquidValue;

            return rescue;
        }
    }
}
