using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    // Platformda hizmet veren (Tesisatçı, Elektrikçi vb.) temsil eder.
    public class Usta
    {
        // Ustanın benzersiz kimlik numarası (ID).
        // Sadece nesne oluşturulurken atanabilir (init-only).
        public int Id { get; init; } // Gereksinim B.1: init-only
        // Ustanın adı ve soyadı.
        public string Ad { get; set; } = string.Empty;
        // Ustanın hizmet verdiği ana uzmanlık alanı (örn: "Tesisat", "Elektrik").

        public string UzmanlikAlani { get; set; } = string.Empty;

        // Ustanın vatandaşlardan aldığı ortalama puan.
        public double Puan { get; set; }

        // Ustanın kişisel iş takvimi (Schedule).
        // Oluşturulurken varsayılan olarak yeni bir Schedule nesnesi atanır.
        public Schedule Schedule { get; set; } = new Schedule();
        // Ustanın o gün için planlanmış ziyaret rotası (Route).
        // Oluşturulurken varsayılan olarak yeni bir Route nesnesi atanır.
        public Route GunlukRota { get; set; } = new Route();
    }
}