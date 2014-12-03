using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;

namespace Keasy5.Domain.Events
{
    [Serializable]
    public class GetUserOrdersEvent : DomainEvent
    {
        public GetUserOrdersEvent(IEntity source) : base(source) { }

        public IEnumerable<SalesOrder> SalesOrders { get; set; }
    }
}
