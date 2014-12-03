using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Domain.Repositories;
using Keasy5.Events.Bus;

namespace Keasy5.Domain.Events.Handlers
{
    public class OrderDispatchedEventHandler : IDomainEventHandler<OrderDispatchedEvent>
    {
        private readonly ISalesOrderRepository salesOrderRepository;
        private readonly IEventBus eventBus;

        public OrderDispatchedEventHandler(ISalesOrderRepository salesOrderRepository, IEventBus bus)
        {
            this.salesOrderRepository = salesOrderRepository;
            this.eventBus = bus;
        }

        public void Handle(OrderDispatchedEvent evnt)
        {
            SalesOrder salesOrder = evnt.Source as SalesOrder;
            salesOrder.DateDispatched = evnt.DispatchedDate;
            salesOrder.Status = SalesOrderStatus.Dispatched;

            eventBus.Publish<OrderDispatchedEvent>(evnt);
        }
    }
}
