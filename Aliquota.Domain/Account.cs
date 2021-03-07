using System;

namespace Aliquota.Domain
{
    public class Account
    {
        //public string Username { get; private set; }

        //public Account(string username = "Admin")
        //{
        //    Username = username;
        //}

        public bool Apply(Application application)
        {
            return 0 < application.Value;
        }

        public Application Withdraw()
        {
            return new Application(this, 0, DateTime.Now);
        }

        public float CalculateIncomeTax(float yearsFromApplication)
        {
            if (0 < yearsFromApplication && yearsFromApplication <= 1)
                return 22.5f;
            else if (1 < yearsFromApplication && yearsFromApplication <= 2)
                return 18.5f;
            else if (2 < yearsFromApplication)
                return 15f;

            else return 0;
        }
    }
}
