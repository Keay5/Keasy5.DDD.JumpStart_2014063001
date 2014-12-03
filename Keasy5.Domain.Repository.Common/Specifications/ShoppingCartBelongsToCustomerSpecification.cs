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
    public class ShoppingCartBelongsToCustomerSpecification : Specification<ShoppingCart>
    {
        private readonly User user;


        public ShoppingCartBelongsToCustomerSpecification(User user)
        {
            this.user = user;
        }

        public override Expression<Func<ShoppingCart, bool>> GetExpression()
        {
            return c => c.User.ID == user.ID;
        }
    }
}
