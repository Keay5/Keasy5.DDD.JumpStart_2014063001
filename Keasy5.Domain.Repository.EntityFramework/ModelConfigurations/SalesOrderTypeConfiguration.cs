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
    public class SalesOrderTypeConfiguration : EntityTypeConfiguration<SalesOrder>
    {
        public SalesOrderTypeConfiguration()
        {
            HasKey<Guid>(s => s.ID);
            Property(s => s.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Ignore(p => p.Subtotal);
        }
    }
}
