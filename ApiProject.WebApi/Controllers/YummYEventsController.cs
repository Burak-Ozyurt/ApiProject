using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummYEventsController : ControllerBase
    {
        private readonly ApiContext _context;

        public YummYEventsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult YummYEventList()
        {
            var values = _context.YummYEvents.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateYummYEvent(YummYEvent YummYEvent)
        {
            _context.YummYEvents.Add(YummYEvent);
            _context.SaveChanges();
            return Ok("Etkinlik başarıyla eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteYummYEvent(int id)
        {
            var value = _context.YummYEvents.Find(id);
            _context.YummYEvents.Remove(value);
            _context.SaveChanges();
            return Ok("Etkinlik başarıyla silindi.");
        }

        [HttpGet("GetYummYEvent")]    //HttpGet olduğu için önceden bir id değeri vermemiz gerekiyor. O yüzden GetYummYEvent diye bir isim verdik.

        public IActionResult GetYummYEvent(int id)
        {
            var value = _context.YummYEvents.Find(id);
            return Ok(value);
        }

        [HttpPut]

        public IActionResult UpdateYummYEvent(YummYEvent YummYEvent)
        {
            _context.YummYEvents.Update(YummYEvent);
            _context.SaveChanges();
            return Ok("Etkinlik başarıyla güncellendi.");
        }
    }
}
