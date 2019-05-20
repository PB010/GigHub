using GigHub.Core;
using GigHub.Core.Dto;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.api
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowDto followDto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Followings.GetFollowingBool(followDto.FollowedId, userId))
                return BadRequest("You are already following him.");

            var follow = new Follow
            {
                FollowedId = followDto.FollowedId,
                FollowerId = userId
            };

            _unitOfWork.Followings.Add(follow);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var follow = _unitOfWork.Followings.GetSingleFollow(id, userId);

            if (follow == null)
                return NotFound();

            _unitOfWork.Followings.Remove(follow);
            _unitOfWork.Complete();

            return Ok(id);
        }

        
    }


}
