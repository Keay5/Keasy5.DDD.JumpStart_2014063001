using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;

namespace Keasy5.Domain.Repository.Common.Specifications
{
    public class UserEmailEqualsSpecification : UserStringEqualsSpecification
    {
        public UserEmailEqualsSpecification(string email)
            : base(email)
        { }

        public override System.Linq.Expressions.Expression<Func<User, bool>> GetExpression()
        {
            return c => c.Email == value;
        }
    }
}
