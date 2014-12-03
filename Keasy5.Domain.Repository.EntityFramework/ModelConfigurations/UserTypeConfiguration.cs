using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;

namespace Keasy5.Domain.Repository.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// Represents the entity type configuration for the <see cref="Customer"/> entity.
    /// </summary>
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of <c>CustomerTypeConfiguration</c> class.
        /// </summary>
        public UserTypeConfiguration()
        {
            HasKey(c => c.ID);
            Property(c => c.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.UserName)
                .IsRequired()
                .HasMaxLength(20);
            Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(20);
            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(80);

            ToTable("Users");
        }
        #endregion
    }
}
