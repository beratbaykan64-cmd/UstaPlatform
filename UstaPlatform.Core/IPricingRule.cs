using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// UstaPlatform.Core/IPricingRule.cs
using UstaPlatform.Domain; // Domain'e referans verdiğimiz için WorkOrder'ı tanır

namespace UstaPlatform.Core
{
    // Gereksinim 4: Plug-in mimarisinin sözleşmesi (contract)
    public interface IPricingRule
    {
        // Bir iş emri ve mevcut fiyatı alır,
        // kuralı uygular ve YENİ fiyatı döner.
        decimal Apply(decimal currentPrice, WorkOrder workOrder);
    }
}