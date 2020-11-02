

using Income.Tax.Willian.Santos.Kinvo.Shared.Entities;
using System;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Entities.Relationships
{
    public class IncomeTaxInterest: Entity
    {
        public IncomeTaxInterest(float? fullProfit, float? profitWithInterest)
        {
            FullProfit = fullProfit;
            ProfitWithInterest = profitWithInterest;
        }

        public Guid ApplicationITId { get; set; }

        public float? FullProfit { get; set; }
        public float? ProfitWithInterest { get; set; }

        public void SetFullProfit(float fullProfit)
        {
            FullProfit = fullProfit;
        }


        /*Ef Relation */

        public ApplicationIT ApplicationIT { get; set; }
    }
}
