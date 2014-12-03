using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;

namespace Keasy5.Domain.Repository.Common.Specifications
{
    public class UserPasswordEqualsSpecification : UserStringEqualsSpecification
    {

        public UserPasswordEqualsSpecification(string password)
            : base(password)
        {
        }

        public override System.Linq.Expressions.Expression<Func<User, bool>> GetExpression()
        {
            return c => c.Password == value;
        }
    }
}
