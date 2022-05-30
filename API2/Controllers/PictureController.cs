using API2.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //todo kubra
    // [Authorize] 
    public class PictureController : Controller
    {
        public IActionResult GetPicture()
        {
            var pictureList = new List<Picture>() {
            new Picture { Id = 1, Name = "kalem", Url = "kalem.jpg"},
            new Picture { Id = 2, Name = "defter", Url = "defter.jpg"},
            new Picture { Id = 3, Name = "silgi", Url = "silgi.jpg" },
            new Picture { Id = 4, Name = "kitap", Url = "kitap.jpg" }
            };
            return Ok(pictureList);

        }
    }
}
