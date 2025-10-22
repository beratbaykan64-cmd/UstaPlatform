using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UstaPlatform.Domain
{
    // Platform üzerinden hizmet talep eden kişiyi temsil eder.
    public class Vatandas
    {
        // Vatandaşın benzersiz kimlik numarası (ID).
        // Sadece nesne oluşturulurken atanabilir (init-only).
        public int Id { get; init; } // Gereksinim B.1: init-only
        // Vatandşın adı ve soyadı.
        public string Ad { get; set; } = string.Empty; 
    }
}