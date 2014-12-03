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
    public class UserRolesSpecification : Specification<UserRole>
    {
        private readonly Guid userID;

        public UserRolesSpecification(User user)
        {
            this.userID = user.ID;
        }

        public override Expression<Func<UserRole, bool>> GetExpression()
        {
            return p => p.UserID == userID;
        }
    }
}
