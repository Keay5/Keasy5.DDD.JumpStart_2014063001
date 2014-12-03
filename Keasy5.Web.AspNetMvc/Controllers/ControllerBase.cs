using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Keasy5.Web.AspNetMvc.Controllers
{
    /// <summary>
    /// 表示“控制器”Controller类型的基类型，
    /// 所有Byteart Retail项目下的Controller都
    /// 应该继承于此基类型。
    /// </summary>
    public class ControllerBase : Controller
    {
        #region Private Constants
        private const string SUCCESS_PAGE_ACTION = "SuccessPage";
        private const string SUCCESS_PAGE_CONTROLLER = "Home";
        #endregion

        #region Protected Property
        /// <summary>
        /// 获取当前用户的ID值
        /// </summary>
        protected Guid UserID
        {
            get
            {
                if (null != Session["UserID"])
                {
                    return (Guid)Session["UserID"];
                }
                else
                {
                    var id = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                    Session["UserID"] = id;

                    return id;
                }
            }

        } 
        #endregion

        #region Protected Methods

        protected ActionResult RedirectToSuccess(string pageTitle,
            string action = "Index",
            string controller = "Home",
            int waitSeconds = 3
            )
        {
            return this.RedirectToAction(SUCCESS_PAGE_ACTION, 
                SUCCESS_PAGE_CONTROLLER, 
                new { pageTitle = pageTitle, retAction = action, retController = controller, waitSeconds = waitSeconds });
        }

        #endregion
    }
}
