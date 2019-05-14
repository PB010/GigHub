using System.Linq;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using GigHub.Dtos;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances
                .Any(a => a.AttendeeId == userId && a.GigId == attendanceDto.GigId))
                return BadRequest("Attendance already exists.");

            var attendance = new Attendance
            {
                GigId = attendanceDto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
