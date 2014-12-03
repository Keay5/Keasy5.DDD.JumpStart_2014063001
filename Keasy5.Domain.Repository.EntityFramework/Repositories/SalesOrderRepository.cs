using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Domain.Repositories;
using Keasy5.Domain.Repository.Common.Specifications;

namespace Keasy5.Domain.Repository.EntityFramework.Repositories
{
    public class SalesOrderRepository : EntityFrameworkRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(IRepositoryContext context)
            : base(context)
        { }

        #region ISalesOrderRepository Members

        public IEnumerable<SalesOrder> FindSalesOrdersByUser(User user)
        {
            return FindAll(new SalesOrderBelongsToUserSpecification(user), sp => sp.DateCreated, SortOrder.Descending);
        }

        public SalesOrder GetSalesOrderByID(Guid orderID)
        {
            //“elp => elp.SalesLines”表示饥饿（立即）加载SalesLines
            return Get(new SalesOrderIDEqualsSpecification(orderID), elp => elp.SalesLines);
        }

        #endregion
    }
}
