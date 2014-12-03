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
    public class SalesOrderBelongsToUserSpecification : Specification<SalesOrder>
    {
        private readonly User user;

        public SalesOrderBelongsToUserSpecification(User user)
        {
            this.user = user;
        }

        public override Expression<Func<SalesOrder, bool>> GetExpression()
        {
            return so => so.User.ID == this.user.ID;
        }
    }
}
