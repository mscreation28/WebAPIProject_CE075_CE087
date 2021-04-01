using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortnerApi
{
    public class ShortUrl
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String ShortKey { get; set; }

        [Required]
        public String Url { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
