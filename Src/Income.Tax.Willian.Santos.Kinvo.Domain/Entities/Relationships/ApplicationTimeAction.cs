
using Income.Tax.Willian.Santos.Kinvo.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Entities.Relationships
{
    public  class ApplicationTimeAction: Entity
    {
        public ApplicationTimeAction(int quantityMonths, int quantityDays)
        {
            QuantityMonths = quantityMonths;
            QuantityDays = quantityDays;
        }

        public Guid ApplicationITId { get; protected set; }


        public int QuantityMonths { get; protected  set; }

        public int QuantityDays { get; protected  set; }
        
        public void SetQuantityMonths(int quantityMonths)
        {
            QuantityMonths = quantityMonths;
        }

        public void SetQuantityDays(int quantityDays)
        {
            QuantityDays = quantityDays;
        }
        
        public void SetTimeAction(int quantityDays, int quantityMonths)
        {
            QuantityDays = quantityDays;
            QuantityMonths = quantityMonths;
        }

        /*Ef Relation */
        public ApplicationIT ApplicationIT { get; set; }
    }
}
