using ApiProject.WebApi.Context;
using ApiProject.WebApi.Dtos.GroupReservationDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public GroupReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GroupReservationList()
        {
            var values = _context.GroupReservations.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateGroupReservation(CreateGroupReservationDto createGroupReservationDto)
        {
            var value = _mapper.Map<GroupReservation>(createGroupReservationDto);
            _context.GroupReservations.Add(value);
            _context.SaveChanges();
            return Ok("Başarıyla eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteGroupReservation(int id)
        {
            var value = _context.GroupReservations.Find(id);
            _context.GroupReservations.Remove(value);
            _context.SaveChanges();
            return Ok("Başarıyla silindi.");
        }

        [HttpGet("GetGroupReservation")]    //HttpGet olduğu için önceden bir id değeri vermemiz gerekiyor. O yüzden GetGroupReservation diye bir isim verdik.

        public IActionResult GetGroupReservation(int id)
        {
            var value = _context.GroupReservations.Find(id);
            return Ok(value);
        }

        [HttpPut]

        public IActionResult UpdateGroupReservation(UpdateGroupReservationDto updateGroupReservationDto)
        {
            var value = _mapper.Map<GroupReservation>(updateGroupReservationDto);
            _context.GroupReservations.Update(value);
            _context.SaveChanges();
            return Ok("Başarıyla güncellendi.");
        }
    }
}
