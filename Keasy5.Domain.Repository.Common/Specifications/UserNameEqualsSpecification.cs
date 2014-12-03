using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;

namespace Keasy5.Domain.Repository.Common.Specifications
{
    public class UserNameEqualsSpecification : UserStringEqualsSpecification
    {
        public UserNameEqualsSpecification(string userName)
            : base(userName)
        {
        }

        public override Expression<Func<User, bool>> GetExpression()
        {
            return c => c.UserName == value;
        }
    }
}
