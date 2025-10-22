using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Core;
using UstaPlatform.Domain;

namespace UstaPlatform.Rules.LoyaltyDiscount
{
    // 101 ID'li sadık müşteriye %10 indirim
    public class LoyaltyDiscountRule : IPricingRule
    {
        public decimal Apply(decimal currentPrice, WorkOrder workOrder)
        {
            if (workOrder.Talep.TalepEden.Id == 101)
            {
                return currentPrice * 0.90m; // %10 indirim
            }
            return currentPrice;
        }
    }
}
