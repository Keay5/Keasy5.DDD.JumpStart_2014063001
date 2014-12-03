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
    public class CategorizationTypeConfiguration : EntityTypeConfiguration<Categorization>
    {
        public CategorizationTypeConfiguration()
        {
            HasKey<Guid>(c => c.ID);
            Property(c => c.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.ProductID)
                .IsRequired();

            Property(c => c.CategoryID)
                .IsRequired();
        }
    }
}
