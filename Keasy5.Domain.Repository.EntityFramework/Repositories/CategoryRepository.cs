using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Domain.Repositories;

namespace Keasy5.Domain.Repository.EntityFramework.Repositories
{
    public class CategoryRepository : EntityFrameworkRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}
