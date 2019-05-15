using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var canceledGig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
            canceledGig.IsCanceled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
