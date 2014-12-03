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
    public class SalesLineTypeConfiguration : EntityTypeConfiguration<SalesLine>
    {
        public SalesLineTypeConfiguration()
        {
            HasKey<Guid>(s => s.ID);
            Property(p => p.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(p => p.SalesOrder)
                .WithMany(p => p.SalesLines);

            Ignore(p => p.LineAmount);
        }
    }
}
