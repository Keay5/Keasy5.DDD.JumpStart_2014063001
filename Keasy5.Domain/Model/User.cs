using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Events;

namespace Keasy5.Domain.Model
{
    /// <summary>
    /// 表示“用户”领域概念的聚合根。
    /// </summary>
    public class User : AggregateRoot
    {
        #region Private Fields
        private string userName;
        private string password;
        private string email;
        private bool isDisabled;
        private DateTime dateRegistered;
        private DateTime? dateLastLogon;
        private string contact;
        private string phoneNumber;
        private Address contactAddress = Address.Emtpy;
        private Address deliveryAddress = Address.Emtpy;
        #endregion


        #region Public Properties
        /// <summary>
        /// 获取或设置当前客户的用户名。
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// 获取或设置当前客户的登录密码。
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// 获取或设置当前客户的电子邮件地址。
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// 获取或设置一个<see cref="Boolean"/>值，
        /// 该值表示当前用户账户是否已被禁用。
        /// </summary>
        /// <remarks>在ByteartRetail V3中，
        /// 仅提供对此属性的管理界面，在实际业务处理中并没有使用到该属性。
        /// </remarks>
        public bool IsDisabled
        {
            get { return isDisabled; }
            set { isDisabled = value; }
        }

        /// <summary>
        /// 获取或设置用户账户注册的时间。
        /// </summary>
        public DateTime DateRegistered
        {
            get { return dateRegistered; }
            set { dateRegistered = value; }
        }

        /// <summary>
        /// 获取或设置用户账户最后一次登录的时间。
        /// </summary>
        /// <remarks>在ByteartRetail V3中，仅提供对此属性的管理界面，在实际业务处理中
        /// 并没有使用到该属性。</remarks>
        public DateTime? DateLastLogon
        {
            get { return dateLastLogon; }
            set { dateLastLogon = value; }
        }

        /// <summary>
        /// 获取或设置当前客户的联系人信息。
        /// </summary>
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        /// <summary>
        /// 获取或设置用户账户的联系电话信息。
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        /// <summary>
        /// 获取或设置用户账户的联系地址。
        /// </summary>
        public Address ContactAddress
        {
            get { return contactAddress; }
            set { contactAddress = value; }
        }

        /// <summary>
        /// 获取或设置用户账户的发货地址。
        /// </summary>
        public Address DeliveryAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// http://www.cnblogs.com/daxnet/archive/2013/04/30/3052029.html
        /// 丰富领域模型
        ///或许这种说法并不恰当，不过在实际中的确有这样的问题。比如，
        /// Byteart Retail中有“用户”和“订单”两种聚合，“用户”本身是不应该聚合“订单”的，
        /// 从领域模型的角度讲，“用户”的存在并不依赖于“订单”（“订单”并非“用户”的组成部分），
        /// 因此它跟“汽车”和“车轮”之间的关系是不同的。
        ///当然，我们有一个很正常的需求：或许某个用户的所有订单信息。
        /// 那既然“用户”没有聚合“订单”，也就无法从用户聚合来导航到其下所有的订单对象，此时又应该怎么办呢？
        /// 在没有领域事件之前，要实现这个需求，只能在应用层先获得用户ID，然后使用用户仓储获得用户实体，
        /// 再使用订单仓储找到该用户的所有订单。
        /// 
        /// 现在，让我们看看，在Byteart Retail引入了领域事件之后，这部分又是如何实现的。.....
        /// </remarks>
        public IEnumerable<SalesOrder> SalesOrders
        {
            get
            {
                IEnumerable<SalesOrder> result = null;
                DomainEvent.Publish<GetUserOrdersEvent>(new GetUserOrdersEvent(this),
                    (getUserOrdersEvent, ret, exc) =>
                    {
                        result = getUserOrdersEvent.SalesOrders;
                    });
                return result;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 返回表示当前Object的字符串。
        /// </summary>
        /// <returns>表示当前对象的字符串。</returns>
        public override string ToString()
        {
            return this.userName;
        }

        /// <summary>
        /// 禁用当前账户。
        /// </summary>
        public void Disable()
        {
            this.isDisabled = true;
        }

        /// <summary>
        /// 启用当前账户。
        /// </summary>
        public void Enable()
        {
            this.isDisabled = false;
        }

        /// <summary>
        /// 为当前用户创建购物篮。
        /// </summary>
        /// <returns>已创建的购物篮实例，该购物篮为当前用户所用。</returns>
        public ShoppingCart CreateShoppingCart()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.User = this;
            return shoppingCart;
        }
        #endregion

    }
}
