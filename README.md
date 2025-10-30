# UstaPlatform - Şehrin Uzmanlık Platformu

Bu proje, **Nesne Yönelimli Programlama (NYP) ve İleri C#** dersi kapsamında geliştirilmiş bir simülasyondur. Arcadia şehrindeki vatandaş taleplerini (Tesisatçı, Elektrikçi vb.) uzmanlarla eşleştiren ve dinamik fiyatlama yapabilen bir platformu hedefler.

# Projenin Amacı

Projenin temel amacı, **Genişletilebilir (Extensible)** ve **Değişime Açık** bir mimari kurmaktır. Sistem, katı kurallarla kodlanmış olmak yerine, yeni iş kuralları ve özelliklerin (örneğin yeni fiyatlandırma indirimleri) ana koda dokunmadan eklenebilmesine olanak tanıyacak şekilde tasarlanmıştır.

## Teknik Mimari ve Tasarım Kararları

Proje, **SOLID** prensiplerine, özellikle de **Açık/Kapalı Prensibi (OCP)** ve **Bağımlılıkların Tersine Çevrilmesi (DIP)** üzerine kuruludur.

Sorumluluklar, birden fazla projeye bölünmüştür:

* **`UstaPlatform.Domain`**: `Usta`, `WorkOrder`, `Talep` gibi temel iş varlıklarını içerir. Projenin kalbidir ve hiçbir yere bağımlı değildir.
* **`UstaPlatform.Core`**: `IPricingRule` (Fiyatlandırma Kuralı Arayüzü) gibi tüm sistemin uyması gereken "sözleşmeleri" (arayüzleri) barındırır.
* **`UstaPlatform.Infrastructure`**: `PricingEngine` (Fiyatlandırma Motoru) gibi altyapısal servisleri içerir.
* **`UstaPlatform.Rules.*`**: `HaftasonuEkUcretiKurali` gibi her bir spesifik iş kuralını içeren bağımsız "eklenti" (plug-in) projeleridir.
* **`UstaPlatform.App`**: Simülasyonun çalıştığı ve test edildiği ana Konsol uygulamasıdır.

###  Dinamik Plug-in Mimarisi (OCP)

Projenin en kritik özelliği, dinamik fiyatlama motorudur.

1.  `PricingEngine` (Motor), ana uygulamaya (`App`) kimin hangi kuralı yazdığını bilmez. Sadece `IPricingRule` "sözleşmesini" bilir.
2.  Uygulama başladığında, `PricingEngine`, `System.Reflection` kullanarak `Rules` klasöründeki tüm `.dll` dosyalarını tarar.
3.  Bu DLL'ler içinden `IPricingRule` arayüzünü uygulayan sınıfları bulur, nesnelerini yaratır ve bir "çalıştırılacak kurallar" listesine ekler.
4.  Fiyat hesaplanırken bu listedeki tüm kurallar (zamlar, indirimler) sırayla uygulanır.

**Avantajı:** Sisteme "Acil Çağrı Zammı" gibi yeni bir kural eklemek için tek yapmamız gereken, `IPricingRule`'ü uygulayan yeni bir sınıf kütüphanesi (DLL) projesi oluşturmak ve derlenmiş halini `Rules` klasörüne bırakmaktır. Ana kod (Motor veya App) **asla değişmez**.

## Nasıl Çalıştırılır?

1.  Projeyi klonlayın.
2.  `UstaPlatform.sln` dosyasını Visual Studio ile açın.
3.  Tüm çözümü **Derleyin (Build)**. (Bu adım, kural `.dll` dosyalarının `UstaPlatform.App/bin/.../Rules` klasörüne kopyalanması için önemlidir).
4.  `UstaPlatform.App` projesini "Başlangıç Projesi" (Startup Project) olarak ayarlayın.
5.  Uygulamayı çalıştırın (F5 veya Ctrl+F5).

Konsol çıktısı, motorun `Rules` klasöründen kaç adet kural yüklediğini ve bu kuralları uygulayarak nihai fiyatı nasıl hesapladığını gösterecektir.
