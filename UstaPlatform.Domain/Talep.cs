using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
 
    // Vatandaş tarafından açılan bir iş talebini temsil eder.
    public class Talep
    {
        // Talebin benzersiz kimlik numarası (ID).
        // Sadece nesne oluşturulurken atanabilir (init-only).
        public int Id { get; init; }

        // İşin ne olduğuna dair vatandaşın girdiği açıklama.
        public string Aciklama { get; set; } = string.Empty;
        // Bu talebi oluşturan Vatandaş nesnesi.
        public Vatandas TalepEden { get; set; } = default!;
        // Talebin sisteme kaydedildiği tarih ve saat.
        // Sadece nesne oluşturulurken atanabilir ve varsayılan olarak o anın zamanını alır.
        public DateTime KayitZamani { get; init; } = DateTime.Now;
    }
}