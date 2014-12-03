﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;

namespace Keasy5.Domain.Repository.EntityFramework.ModelConfigurations
{
    public class UserRoleTypeConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleTypeConfiguration()
        {
            HasKey<Guid>(ur => ur.ID);
            Property(ur => ur.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(ur => ur.RoleID)
                .IsRequired();
            Property(ur => ur.UserID)
                .IsRequired();
        }
    }
}
