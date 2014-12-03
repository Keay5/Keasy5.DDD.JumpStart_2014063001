using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Events.Bus;

namespace Keasy5.Domain.Events.Handlers
{
    public class OrderConfirmedEventHandler : IDomainEventHandler<OrderConfirmedEvent>
    {
        private readonly IEventBus bus;

        public OrderConfirmedEventHandler(IEventBus bus)
        {
            this.bus = bus;
        }

        public void Handle(OrderConfirmedEvent evnt)
        {
            SalesOrder salesOrder = evnt.Source as SalesOrder;
            salesOrder.DateDelivered = evnt.ConfirmedDate;
            salesOrder.Status = SalesOrderStatus.Delivered;

            bus.Publish<OrderConfirmedEvent>(evnt);
        }
    }
}
