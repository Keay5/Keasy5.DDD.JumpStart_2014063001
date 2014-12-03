﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Events;
using Keasy5.Infrastructure;

namespace Keasy5.Events.Handlers
{
    /// <summary>
    /// 表示向外发送邮件的事件处理器。
    /// </summary>
    [HandlesAsynchronously]
    public class SendEmailHandler : IEventHandler<OrderDispatchedEvent>, IEventHandler<OrderConfirmedEvent>
    {
        public SendEmailHandler()
        { }

        #region IEventHandler<OrderDispatchedEvent> Members
        /// <summary>
        /// 处理给定的事件。
        /// </summary>
        /// <param name="evnt">需要处理的事件。</param>
        public void Handle(OrderDispatchedEvent evnt)
        {
            try
            {
                // 此处仅为演示，所以邮件内容很简单。可以根据自己的实际情况做一些复杂的邮件功能，比如
                // 使用邮件模板或者邮件风格等。
                Utils.SendEmail(evnt.UserEmailAddress,
                    "您的订单已经发货",
                    string.Format("您的订单 {0} 已于 {1} 发货。有关订单的更多信息，请与系统管理员联系。",
                    evnt.OrderID.ToString().ToUpper(), evnt.DispatchedDate));
            }
            catch (Exception ex)
            {
                // 如遇异常，直接记Log
                Utils.Log(ex);
            }
        }

        #endregion

        #region IEventHandler<OrderConfirmedEvent> Members
        /// <summary>
        /// 处理给定的事件。
        /// </summary>
        /// <param name="evnt">需要处理的事件。</param>
        public void Handle(OrderConfirmedEvent evnt)
        {
            try
            {
                // 此处仅为演示，所以邮件内容很简单。可以根据自己的实际情况做一些复杂的邮件功能，比如
                // 使用邮件模板或者邮件风格等。
                Utils.SendEmail(evnt.UserEmailAddress,
                    "您的订单已经确认收货",
                    string.Format("您的订单 {0} 已于 {1} 确认收货。有关订单的更多信息，请与系统管理员联系。",
                    evnt.OrderID.ToString().ToUpper(), evnt.ConfirmedDate));
            }
            catch (Exception ex)
            {
                // 如遇异常，直接记Log
                Utils.Log(ex);
            }
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == null)
                return false;
            return this.GetType() == obj.GetType();
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }
    }
}
