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
    public class ShoppingCartItemHasProductSpecification : Specification<ShoppingCartItem>
    {

        private readonly Product product;

        public ShoppingCartItemHasProductSpecification(Product product)
        {
            this.product = product;
        }

        public override Expression<Func<ShoppingCartItem, bool>> GetExpression()
        {
            return p => p.Product.ID == product.ID;
        }
    }
}
