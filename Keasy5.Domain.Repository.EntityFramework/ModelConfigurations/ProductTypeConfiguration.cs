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
    /// Represents the entity type configuration for the 
    /// <see cref="Laptop"/> entity.
    /// </summary>
    public class ProductTypeConfiguration : EntityTypeConfiguration<Product>
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of <c>LaptopTypeConfiguration</c> class.
        /// </summary>
        public ProductTypeConfiguration()
        {
            HasKey<Guid>(p => p.ID);
            Property(p => p.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            Property(p => p.Description)
                .IsRequired();

            Property(p => p.ImageUrl)
                .HasMaxLength(255);
        }
        #endregion
    }
}
