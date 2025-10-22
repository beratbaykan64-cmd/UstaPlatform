using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// UstaPlatform.Domain/Route.cs
using System.Collections;

namespace UstaPlatform.Domain
{
    // Gereksinim B.4: Özel IEnumerable<T> Koleksiyonu
    public class Route : IEnumerable<(int X, int Y)>
    {
        private readonly List<(int X, int Y)> _adresler = new();

        // Koleksiyon başlatıcıları (Collection Initializers) desteklemek için
        // public void Add(int X, int Y) metodu
        public void Add(int X, int Y)
        {
            _adresler.Add((X, Y));
        }

        // IEnumerable arayüzünün gerektirdiği metotlar
        public IEnumerator<(int X, int Y)> GetEnumerator()
        {
            return _adresler.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
