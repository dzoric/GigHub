using GigHub.Core.Models;
using GigHub.Persistence;
using GigHub.Persistence.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace GigHub.Tests.Persistence.Repositories
{
    [TestClass]
    public class NotificationRepositoryTests
    {
        private NotificationRepository _repository;
        private Mock<DbSet<UserNotification>> _mockUserNotifications;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockUserNotifications = new Mock<DbSet<UserNotification>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.UserNotifications).Returns(_mockUserNotifications.Object);

            _repository = new NotificationRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetUnreadNotificationsList_NotificationsAreRead_ShouldNotBeReturned()
        {
            var userNotification = new UserNotification() {UserId = "1", IsRead = true };

            _mockUserNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetUnreadNotificationsList("1");

            notifications.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUnreadNotificationsList_UserIsNotTheSame_ShouldNotBeReturned()
        {
            var userNotification = new UserNotification() { UserId = "1" };

            _mockUserNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetUnreadNotificationsList(userNotification.UserId + "-");

            notifications.Should().BeEmpty();
        }
    }
}
