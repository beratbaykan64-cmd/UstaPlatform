using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;  
using UstaPlatform.Core;
using UstaPlatform.Domain;

namespace UstaPlatform.Infrastructure
{
    public class PricingEngine
    {
        // 1. DLL'leri Yükle ve Kuralları Bul
        public List<IPricingRule> LoadRules(string folderPath)
        {
            var rules = new List<IPricingRule>();

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Kural klasörü bulunamadı: {folderPath}");
                return rules;
            }

            // Klasördeki .dll dosyalarını bul
            var dllFiles = Directory.GetFiles(folderPath, "*.dll");

            foreach (var file in dllFiles)
            {
                try
                {
                    // DLL'i belleğe yükle
                    var assembly = Assembly.LoadFrom(file);

                    // DLL içindeki IPricingRule arayüzünü uygulayan sınıfları bul
                    var types = assembly.GetTypes()
                        .Where(t => typeof(IPricingRule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                    foreach (var type in types)
                    {
                        // Sınıftan bir nesne yarat (instance)
                        if (Activator.CreateInstance(type) is IPricingRule rule)
                        {
                            rules.Add(rule);
                            Console.WriteLine($"-> Kural yüklendi: {type.Name}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Kural yüklenirken hata: {Path.GetFileName(file)} - {ex.Message}");
                }
            }
            return rules;
        }

        // 2. Yüklenen Kurallara Göre Fiyatı Hesapla
        public decimal CalculatePrice(WorkOrder workOrder, List<IPricingRule> rules)
        {
            // Başlangıç fiyatını İş Emri'nin taban ücretinden al
            decimal price = workOrder.BaseFee;

            // Tüm kuralları sırayla uygula (Kompozisyon)
            foreach (var rule in rules)
            {
                price = rule.Apply(price, workOrder);
            }

            return price;
        }
    }
}