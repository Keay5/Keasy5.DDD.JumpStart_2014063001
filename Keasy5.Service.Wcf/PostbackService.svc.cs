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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PostbackService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PostbackService.svc 或 PostbackService.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    
    public class PostbackService : IPostbackService
    {
        private readonly IPostbackService postbackServiceImpl = ServiceLocator.Instance.GetService<IPostbackService>();
        public PostbackDataObject GetPostback()
        {
            try
            {
                return postbackServiceImpl.GetPostback();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void Dispose() { postbackServiceImpl.Dispose(); }
    }
}
