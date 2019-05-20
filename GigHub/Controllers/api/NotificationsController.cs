using AutoMapper;
using GigHub.Core;
using GigHub.Core.Dto;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notifications.GetNotificationsForCurrentUser(userId);
            

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        

        [HttpPost]
        public IHttpActionResult NotificationsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notifications.GetUnreadNotifications(userId);

            notifications.ForEach(n => n.ReadNotification());

            _unitOfWork.Complete();

            return Ok();

        }

        
    }
}
