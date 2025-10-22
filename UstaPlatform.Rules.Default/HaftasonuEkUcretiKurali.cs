using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Core;
using UstaPlatform.Domain;

namespace UstaPlatform.Rules.Default
{
    // IPricingRule arayüzünü uygular
    public class HaftasonuEkUcretiKurali : IPricingRule
    {
        public decimal Apply(decimal currentPrice, WorkOrder workOrder)
        {
            var planlananTarih = workOrder.PlanlananTarih;

            // Eğer gün Pazar veya Cumartesi ise %20 ek ücret uygula
            if (planlananTarih.DayOfWeek == DayOfWeek.Saturday ||
                planlananTarih.DayOfWeek == DayOfWeek.Sunday)
            {
                return currentPrice * 1.20m;
            }

            // Değilse, fiyatı değiştirme
            return currentPrice;
        }
    }
}