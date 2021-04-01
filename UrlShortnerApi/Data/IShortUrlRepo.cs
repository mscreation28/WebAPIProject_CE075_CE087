using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortnerApi.Data
{
    public interface IShortUrlRepo
    {
        IEnumerable<ShortUrl> GetAllUrls();

        ShortUrl GetUrlbykey(String key);

        ShortUrl CreateShortUrl(String url);

        bool checkUrl(String orignalUrl);
    }
}
