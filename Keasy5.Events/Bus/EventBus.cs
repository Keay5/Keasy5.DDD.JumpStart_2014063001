using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keasy5.Infrastructure;

namespace Keasy5.Events.Bus
{
    public class EventBus : DisposableObject, IEventBus
    {
        private readonly Guid id = Guid.NewGuid();
        private readonly ThreadLocal<Queue<object>> messageQueue = new ThreadLocal<Queue<object>>(() => new Queue<object>());
        private readonly IEventAggregator aggregator;
        private ThreadLocal<bool> committed = new ThreadLocal<bool>(() => true);
        private readonly MethodInfo publishMethod;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregator"></param>
        /// <remarks>
        ///    参数IEventAggregator aggregator 的一个实现：EventAggregator<see cref="EventAggregator"/>
        /// </remarks>
        public EventBus(IEventAggregator aggregator)
        {

            this.aggregator = aggregator;

            //得到aggregator对象中的名为Publish的函数信息，类型是MethodInfo
            // 1.相关资料：C# 反射泛型
            //    http://www.cnblogs.com/easy5weikai/p/3790589.html
            publishMethod = (from m in aggregator.GetType().GetMethods()
                             let parameters = m.GetParameters()
                             let methodName = m.Name
                             where methodName == "Publish" &&
                             parameters != null &&
                             parameters.Length == 1
                             select m).First();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                messageQueue.Dispose();
                committed.Dispose();
            }
        }

        #region IBus Members

        public void Publish<TMessage>(TMessage message)
            where TMessage : class, IEvent
        {
            messageQueue.Value.Enqueue(message);
            committed.Value = false;
        }

        public void Publish<TMessage>(IEnumerable<TMessage> messages)
            where TMessage : class, IEvent
        {
            foreach (var message in messages)
                Publish(message);
        }

        public void Clear()
        {
            messageQueue.Value.Clear();
            committed.Value = true;
        }

        #endregion

        #region IUnitOfWork Members

        public bool DistributedTransactionSupported
        {
            get { return false; }
        }

        public bool Committed
        {
            get { return committed.Value; }
        }

        public void Commit()
        {
            while (messageQueue.Value.Count > 0)
            {
                var evnt = messageQueue.Value.Dequeue();
                var evntType = evnt.GetType();
                //设置aggregator的publish方法的泛型参数类型，
                var method = publishMethod.MakeGenericMethod(evntType);
                //调用aggregator对象的publish的泛型方法
                //        void Publish<TEvent>(TEvent domainEvent) where TEvent : class, IEvent;
                method.Invoke(aggregator, new object[] { evnt });
            }
            committed.Value = true;
        }

        public void Rollback()
        {
            Clear();
        }

        public Guid ID
        {
            get { return id; }
        }

        #endregion
    }
}
