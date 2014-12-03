using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Keasy5.Domain.Model;
using Keasy5.Domain.Specifications;

namespace Keasy5.Domain.Repository.Common.Specifications
{
    public abstract class UserStringEqualsSpecification : Specification<User>
    {
        protected readonly string value;

        public UserStringEqualsSpecification(string value)
        {
            this.value = value;
        }
    }
}
