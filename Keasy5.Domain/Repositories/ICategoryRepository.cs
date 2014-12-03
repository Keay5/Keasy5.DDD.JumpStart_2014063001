using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;

namespace Keasy5.Domain.Repositories
{
    /// <summary>
    /// 表示用于“商品分类”聚合根的仓储接口。
    /// </summary>
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
