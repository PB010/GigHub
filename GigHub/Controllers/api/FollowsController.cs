using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

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
        public IHttpActionResult Follow([FromBody]string userId)
        {
            var loggedInUserId = User.Identity.GetUserId();

            if (_context.Follows
                .Any(f => f.FollowerId == loggedInUserId && f.FollowedId == userId))
                return BadRequest("You are already following him.");

            var follow = new Follow
            {
                FollowedId = userId,
                FollowerId = loggedInUserId
            };

            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }


}
