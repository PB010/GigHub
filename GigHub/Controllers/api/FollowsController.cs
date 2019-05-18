using System.Data.Entity;
using GigHub.Dto;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.api
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowDto followDto)
        {
            var loggedInUserId = User.Identity.GetUserId();

            if (_context.Follows
                .Any(f => f.FollowerId == loggedInUserId && f.FollowedId == followDto.FollowedId))
                return BadRequest("You are already following him.");

            var follow = new Follow
            {
                FollowedId = followDto.FollowedId,
                FollowerId = loggedInUserId
            };

            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var follow = _context.Follows.Single(
                f => f.FollowerId == userId 
                     && f.FollowedId == id);

            if (follow == null)
                return NotFound();

            _context.Follows.Remove(follow);
            _context.SaveChanges();

            return Ok(id);
        }
    }


}
