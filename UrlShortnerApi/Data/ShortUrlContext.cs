using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortnerApi.Data
{
    public class ShortUrlContext : DbContext
    {
        public ShortUrlContext(DbContextOptions<ShortUrlContext> opt) : base(opt)
        {

        }

        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
