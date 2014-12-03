using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Domain.Specifications;

namespace Keasy5.Domain.Repository.Common.Specifications
{
    public class SalesOrderIDEqualsSpecification : Specification<SalesOrder>
    {
        private readonly Guid orderID;

        public SalesOrderIDEqualsSpecification(Guid orderID)
        {
            this.orderID = orderID;
        }

        public override Expression<Func<SalesOrder, bool>> GetExpression()
        {
            return p => p.ID == this.orderID;
        }
    }
}
