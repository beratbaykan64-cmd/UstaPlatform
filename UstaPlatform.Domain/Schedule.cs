using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// UstaPlatform.Domain/Schedule.cs
namespace UstaPlatform.Domain
{
    public class Schedule
    {
        // İş emirlerini tarihe göre saklayan bir sözlük
        private readonly Dictionary<DateOnly, List<WorkOrder>> _isEmirleri = new();

        // Gereksinim B.3: Dizinleyici 
        // Schedule[tarih] yazdığımızda o güne ait listeyi döner
        public List<WorkOrder> this[DateOnly gun]
        {
            get
            {
                if (!_isEmirleri.ContainsKey(gun))
                {
                    // O gün için bir liste yoksa, oluştur ve ekle
                    _isEmirleri[gun] = new List<WorkOrder>();
                }
                return _isEmirleri[gun];
            }
        }
    }
}
