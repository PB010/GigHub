using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Core.Models;
using GigHub.Persistence;

namespace GigHub.Controllers
{
    public class FollowersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Followers
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var followed = _context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followed)
                .ToList();

            return View(followed);
        }
    }
}