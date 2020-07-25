using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    public interface Iapplicationservice
    {
        void CreateApplication(application application);
        void RescueApplication(application application);
    }
}
