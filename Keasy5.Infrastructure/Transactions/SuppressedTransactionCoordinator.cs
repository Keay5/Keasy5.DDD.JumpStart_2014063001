using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keasy5.Infrastructure.Transactions
{

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// http://www.cnblogs.com/daxnet/archive/2013/04/30/3052029.html
    /// 
    ///如果选用的Event Bus不支持MSDTC，
    ///那么coordinator就会是SuppressedTransactionCoordinator，
    ///也就意味着没有任何分布式事务的保障。
    ///例如，ByteartRetail.Events.Bus.EventBus类采用事件聚合器（Event Aggregator）
    ///来实现电子邮件发送功能。“电子邮件发送”本身也是不支持MSDTC的，
    ///所以，此处的事务性是无法得到保障的。
    ///不过，在SuppressedTransactionCoordinator进行Commit的时候，
    ///会首先提交数据库事务，一旦发生异常，
    ///那么后面对Event Bus的提交也就不会进行，
    ///对于“电子邮件发送”这个应用场景来说，
    ///已经可以满足了（因为不会出现数据没有更改，却已把电子邮件发出的尴尬局面）。
    //// </remarks>
    internal sealed class SuppressedTransactionCoordinator : TransactionCoordinator
    {
        public SuppressedTransactionCoordinator(params IUnitOfWork[] unitOfWorks)
            : base(unitOfWorks)
        {
        }

    }
}
