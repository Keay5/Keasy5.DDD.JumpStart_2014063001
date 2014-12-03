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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UserService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UserService.svc 或 UserService.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class UserService : IUserService
    {
        private readonly IUserService userServiceImpl = ServiceLocator.Instance.GetService<IUserService>();
        public UserDataObjectList CreateUsers(UserDataObjectList userDataObjects)
        {
            try
            {
                return userServiceImpl.CreateUsers(userDataObjects);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public Boolean ValidateUser(String userName, String password)
        {
            try
            {
                return userServiceImpl.ValidateUser(userName, password);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public Boolean DisableUser(UserDataObject userDataObject)
        {
            try
            {
                return userServiceImpl.DisableUser(userDataObject);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public Boolean EnableUser(UserDataObject userDataObject)
        {
            try
            {
                return userServiceImpl.EnableUser(userDataObject);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public UserDataObjectList UpdateUsers(UserDataObjectList userDataObjects)
        {
            try
            {
                return userServiceImpl.UpdateUsers(userDataObjects);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void DeleteUsers(UserDataObjectList userDataObjects)
        {
            try
            {
                userServiceImpl.DeleteUsers(userDataObjects);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public UserDataObject GetUserByKey(Guid ID, QuerySpec spec)
        {
            try
            {
                return userServiceImpl.GetUserByKey(ID, spec);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public UserDataObject GetUserByEmail(String email, QuerySpec spec)
        {
            try
            {
                return userServiceImpl.GetUserByEmail(email, spec);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public UserDataObject GetUserByName(String userName, QuerySpec spec)
        {
            try
            {
                return userServiceImpl.GetUserByName(userName, spec);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public UserDataObjectList GetUsers(QuerySpec spec)
        {
            try
            {
                return userServiceImpl.GetUsers(spec);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public RoleDataObjectList GetRoles()
        {
            try
            {
                return userServiceImpl.GetRoles();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public RoleDataObject GetRoleByKey(Guid id)
        {
            try
            {
                return userServiceImpl.GetRoleByKey(id);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public RoleDataObjectList CreateRoles(RoleDataObjectList roleDataObjects)
        {
            try
            {
                return userServiceImpl.CreateRoles(roleDataObjects);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public RoleDataObjectList UpdateRoles(RoleDataObjectList roleDataObjects)
        {
            try
            {
                return userServiceImpl.UpdateRoles(roleDataObjects);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void DeleteRoles(IDList roleIDs)
        {
            try
            {
                userServiceImpl.DeleteRoles(roleIDs);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void AssignRole(Guid userID, Guid roleID)
        {
            try
            {
                userServiceImpl.AssignRole(userID, roleID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void UnassignRole(Guid userID)
        {
            try
            {
                userServiceImpl.UnassignRole(userID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public RoleDataObject GetUserRoleByUserName(String userName)
        {
            try
            {
                return userServiceImpl.GetUserRoleByUserName(userName);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public SalesOrderDataObjectList GetSalesOrders(String userName)
        {
            try
            {
                return userServiceImpl.GetSalesOrders(userName);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void Dispose() { userServiceImpl.Dispose(); }
    }
}
