using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Domain.Repositories;
using Keasy5.Events;

namespace Keasy5.Domain.Events.Handlers
{
    [HandlesAsynchronously]
    public class GetUserOrdersEventHandler : IDomainEventHandler<GetUserOrdersEvent>
    {
        private readonly ISalesOrderRepository salesOrderRepository;

        public GetUserOrdersEventHandler(ISalesOrderRepository salesOrderRepository)
        {
            this.salesOrderRepository = salesOrderRepository;
        }

        public void Handle(GetUserOrdersEvent evnt)
        {
            var user = evnt.Source as User;
            evnt.SalesOrders = this.salesOrderRepository.FindSalesOrdersByUser(user);
        }
    }
}
