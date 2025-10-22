using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    // Bir talebin onaylanmış, bir ustaya atanmış ve planlanmış halini temsil eder.
    // Bu sınıf, faturalandırılacak ve çizelgeye eklenecek olan somut "iş"tir.
    public class WorkOrder
    {
        // İş emrinin benzersiz kimlik numarası (ID).
        // Sadece nesne oluşturulurken atanabilir (init-only).

        public int Id { get; init; }

        // Bu iş emrinin hangi talebe istinaden oluşturulduğunu belirtir.
        public Talep Talep { get; set; } = default!;

        // İş emrinin atandığı Usta nesnesi.
        public Usta AtanmisUsta { get; set; } = default!;
        // İşin yapılması için planlanan tarih ve saat.
        public DateTime PlanlananTarih { get; set; }

        /// İşin kural motoruna girmeden önceki temel ücreti.
        public decimal BaseFee { get; set; }

        /// Fiyatlama motoru tarafından tüm kurallar 
        /// uygulandıktan sonra hesaplanan nihai ücret.
        public decimal Fiyat { get; set; }
    }
}