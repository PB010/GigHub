using GigHub.Core;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id, userId);

            if (gig.IsCanceled)
                return NotFound();

            gig.Cancel();
            
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var gigs = _unitOfWork.Gigs.GigsToList();

            return Ok(gigs);
        }

        
    }
}
