using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ByteartRetail.DataObjects;
using Keasy5.DataObject;
using Keasy5.Infrastructure;
using Keasy5.ServiceContract;

namespace Keasy5.Service.Wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“OrderService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 OrderService.svc 或 OrderService.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class OrderService : IOrderService
    {
        private readonly IOrderService orderServiceImpl = ServiceLocator.Instance.GetService<IOrderService>();
        public Int32 GetShoppingCartItemCount(Guid userID)
        {
            try
            {
                return orderServiceImpl.GetShoppingCartItemCount(userID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void AddProductToCart(Guid customerID, Guid productID, Int32 quantity)
        {
            try
            {
                orderServiceImpl.AddProductToCart(customerID, productID, quantity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public ShoppingCartDataObject GetShoppingCart(Guid customerID)
        {
            try
            {
                return orderServiceImpl.GetShoppingCart(customerID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void UpdateShoppingCartItem(Guid shoppingCartItemID, Int32 quantity)
        {
            try
            {
                orderServiceImpl.UpdateShoppingCartItem(shoppingCartItemID, quantity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void DeleteShoppingCartItem(Guid shoppingCartItemID)
        {
            try
            {
                orderServiceImpl.DeleteShoppingCartItem(shoppingCartItemID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public SalesOrderDataObject Checkout(Guid customerID)
        {
            try
            {
                return orderServiceImpl.Checkout(customerID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void Confirm(Guid orderID)
        {
            try
            {
                orderServiceImpl.Confirm(orderID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void Dispatch(Guid orderID)
        {
            try
            {
                orderServiceImpl.Dispatch(orderID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public SalesOrderDataObjectList GetSalesOrdersForUser(Guid userID)
        {
            try
            {
                return orderServiceImpl.GetSalesOrdersForUser(userID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public SalesOrderDataObjectList GetAllSalesOrders()
        {
            try
            {
                return orderServiceImpl.GetAllSalesOrders();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public SalesOrderDataObject GetSalesOrder(Guid orderID)
        {
            try
            {
                return orderServiceImpl.GetSalesOrder(orderID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void Dispose() { orderServiceImpl.Dispose(); }
    }
}
