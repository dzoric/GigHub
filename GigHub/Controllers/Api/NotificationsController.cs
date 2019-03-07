using AutoMapper;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using Ninject;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace GigHub.Controllers.Api
{


    [Authorize]
    public class NotificationsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public NotificationsController()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            _unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _unitOfWork.Notifications.GetUnreadNotificationsList(userId);

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            _unitOfWork.Notifications.MarkNotificationsAsRead(userId);

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
