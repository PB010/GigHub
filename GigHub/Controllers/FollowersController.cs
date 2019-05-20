using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Persistence;

namespace GigHub.Controllers
{
    public class FollowersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Followers
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var followed = _unitOfWork.Followings.GetAllFollowings(userId);

            return View(followed);
        }

        
    }
}