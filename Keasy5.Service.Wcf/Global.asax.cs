using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Keasy5.Application;
using Keasy5.Domain.Repository.EntityFramework;
using Keasy5.Domain.Repository.MongoDb;

namespace Keasy5.Service.Wcf
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 创建.Net WCF服务,可参看
    ///      http://www.cnblogs.com/daxnet/archive/2011/02/14/1954427.html
    /// </remarks>
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ByteartRetailDbContextInitailizer.Initialize();  //EntityFramwork初始化
            MongoDBBootstrapper.Bootstrap();                 //MongoDb初始化
            ApplicationService.Initialize();

            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}