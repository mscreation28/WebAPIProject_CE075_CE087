using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortnerApi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortnerApi.Controllers
{
    [Route("")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        // GET: api/<ShortUrlController>
        private readonly IShortUrlRepo _respository;        

        public ShortUrlController(IShortUrlRepo repository)
        {
            _respository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShortUrl>> GetUrls()
        {
            //var urlItems = _respository.GetAllUrls();

            return Ok();
        }

        [HttpGet("{key}")]
        public ActionResult<ShortUrl> GetUrlbyId(String key)
        {
            var url = _respository.GetUrlbykey(key);
            if (url == null)
            {
                return NotFound("Not found!");
            }
            return Redirect(url.Url);
            //return Ok();
        }

        //// GET api/<ShortUrlController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ShortUrlController>

        [HttpPost]
        public ActionResult<ShortUrl> PostUrl([FromBody] String url)
        {
            if (_respository.checkUrl(url))
            {
                var shortUrl = _respository.CreateShortUrl(url);                
                return Ok(shortUrl);
            }
            else
            {
                return NotFound("Enter valid url!");
            }            
        }
    }
}
