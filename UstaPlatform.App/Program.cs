// UstaPlatform.App/Program.cs
using UstaPlatform.Domain;
using UstaPlatform.Infrastructure;

Console.WriteLine("UstaPlatform Simülatörü Başlatıldı...");

// 1. FİYATLAMA MOTORUNU HAZIRLA
var engine = new PricingEngine();

// Kuralların olduğu klasörün yolunu belirle
// (Çalışan .exe dosyasının yanındaki "Rules" klasörü)
string rulesPath = Path.Combine(AppContext.BaseDirectory, "Rules");
Console.WriteLine($"Kural klasörü taranıyor: {rulesPath}");

// Motoru çalıştır ve kuralları yükle
var loadedRules = engine.LoadRules(rulesPath);
Console.WriteLine($"Toplam {loadedRules.Count} kural yüklendi.");
Console.WriteLine("------------------------------------------");


// 2. DEMO VERİSİ OLUŞTURMA 
var vatandas = new Vatandas { Id = 101, Ad = "Ayşe Yılmaz" };
var usta = new Usta
{
    Id = 1,
    Ad = "Ali Usta",
    UzmanlikAlani = "Tesisat"
};

// Gereksinim B.4 testi: Route koleksiyon başlatıcısı
usta.GunlukRota = new Route { { 10, 20 }, { 30, 45 } };

var talep = new Talep
{
    Id = 1001,
    Aciklama = "Mutfak musluğu sızdırıyor",
    TalepEden = vatandas
};

// 3. İŞ EMRİ OLUŞTUR (Haftasonu kuralını test etmek için )
var workOrder = new WorkOrder
{
    Id = 501,
    Talep = talep,
    AtanmisUsta = usta,
    PlanlananTarih = new DateTime(2025, 10, 26), // ÖNEMLİ: Bu bir Pazar günü
    BaseFee = 100m // Taban ücret 100 TL
};

Console.WriteLine($"İş Emri #{workOrder.Id} oluşturuldu.");
Console.WriteLine($"Usta: {usta.Ad}, Vatandaş: {vatandas.Ad}");
Console.WriteLine($"Planlanan Tarih: {workOrder.PlanlananTarih.ToShortDateString()} ({workOrder.PlanlananTarih.DayOfWeek})");
Console.WriteLine($"Taban Fiyat: {workOrder.BaseFee:N2} TL");


// 4. FİYATI HESAPLA (Motoru kullanarak)
workOrder.Fiyat = engine.CalculatePrice(workOrder, loadedRules);


// 5. ÇİZELGEYE EKLE (Gereksinim B.3: Indexer kullanarak)
var gun = DateOnly.FromDateTime(workOrder.PlanlananTarih);
usta.Schedule[gun].Add(workOrder);

Console.WriteLine("İş emri ustanın çizelgesine eklendi.");
Console.WriteLine("------------------------------------------");
Console.WriteLine($"NİHAİ FİYAT (Kurallar uygulandı): {workOrder.Fiyat:N2} TL");
Console.WriteLine("------------------------------------------");