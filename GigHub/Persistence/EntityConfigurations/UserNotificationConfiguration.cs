﻿using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.EntityConfigurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasRequired(n => n.User)
            .WithMany(u => u.UserNotifications)
            .WillCascadeOnDelete(false);
        }
    }
}