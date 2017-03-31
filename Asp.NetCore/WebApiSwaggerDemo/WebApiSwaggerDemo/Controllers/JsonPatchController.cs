using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    public class JsonPatchController : Controller
    {

        // GET api/values/5
        //[FromBody] JsonPatchDocument<SpeakerReview> jsonPatchDocument
        //[HttpGet]
        [HttpPatch("{id}")]
        public IActionResult Get()
        {
            var jsonPatchDocument = new JsonPatchDocument();
            jsonPatchDocument.Replace("/Review", "very very good speaker");
            //[{"op":"replace", "path":"/review", "value":"very very good speaker"}]
            if (jsonPatchDocument==null) {
                return BadRequest();
            }
            var speakerFromdb = new SpeakerReview { ReviewId = 2, SpeakerId = 101, Rate = 2.5M, Review = "Good speaker.", ReviewDate = DateTime.UtcNow.AddDays(-1) };
            jsonPatchDocument.ApplyTo(speakerFromdb);
            return Json(speakerFromdb);
        }
    }

    public class SpeakerReview
    {

        public int ReviewId { get; set; }
        public int SpeakerId { get; set; }
        public decimal Rate { get; set; }
        public string Review { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
