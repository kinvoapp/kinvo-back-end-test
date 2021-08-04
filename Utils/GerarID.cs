using System;
using System.Collections.Generic;
using System.Text;

namespace Alicota.Utils
{
    class GerarID
    {
        private static int ID = 1;

        public static int Gerar()
        {
            return ID++;
        }
    }
}
