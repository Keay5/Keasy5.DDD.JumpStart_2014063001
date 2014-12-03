using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Domain.Repositories;

namespace Keasy5.Domain.Repository.MongoDb.Repositories
{
    public class CategoryRepository : MongoDBRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IRepositoryContext context) : base(context) { }
    }
}
