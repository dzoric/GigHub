using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(u => u.Followers)
            .WithRequired(f => f.Followee)
            .WillCascadeOnDelete(false);

            HasMany(u => u.Followees)
            .WithRequired(f => f.Follower)
            .WillCascadeOnDelete(false);
        }
    }
}