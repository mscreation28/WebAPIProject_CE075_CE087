using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UrlShortnerApi.Data
{
    public class ShortUrlRepo : IShortUrlRepo
    {
        private readonly ShortUrlContext _context;

        public ShortUrlRepo(ShortUrlContext context)
        {
            _context = context;
        }
        public IEnumerable<ShortUrl> GetAllUrls()
        {
            var urlItems = _context.ShortUrls.ToList();

            return urlItems;
        }

        public ShortUrl GetUrlbykey(String key)
        {
            var url = _context.ShortUrls.FirstOrDefault(x=> x.ShortKey == key);
            return url;
        }

        public ShortUrl CreateShortUrl(String originalUrl)
        {
            string shortUrl = "";            
            ShortUrl url = _context.ShortUrls.FirstOrDefault(x=> x.Url == originalUrl);

            if (url == null)
            {
                shortUrl = Guid.NewGuid().ToString().Substring(0, 8).ToLower();
                url = new ShortUrl { ShortKey = shortUrl, Url = originalUrl, DateCreated = DateTime.Now };

                _context.ShortUrls.Add(url);
                _context.SaveChanges();
            }
            return url;
        }

        public bool checkUrl(String orignalUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(orignalUrl) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
    }
}
