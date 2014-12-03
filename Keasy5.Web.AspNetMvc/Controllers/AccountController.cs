﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ByteartRetail.DataObjects;
using Keasy5.Web.AspNetMvc.Models;

namespace Keasy5.Web.AspNetMvc.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///     Form认证相关资料：
    ///      http://www.cnblogs.com/liping19851014/archive/2007/10/09/917982.html
    /// </remarks>
    [Authorize]
    [HandleError]
    public class AccountController : ControllerBase
    {
        #region 登录

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码不正确！");
                }
            }
            return View();
        } 

        #endregion

        #region 注销
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["UserID"] = null;
            return RedirectToAction("Index", "Home");
        } 
        #endregion

        #region 注册

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserAccountModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    MembershipCreateStatus createStatus;
                    (Membership.Provider as ByteartRetailMembershipProvider).CreateUser(model.UserName,
                        model.Password,
                        model.Email,
                        null,
                        null,
                        true,
                        null,
                        model.Contact,
                        model.PhoneNumber,
                        new AddressDataObject
                        {
                            Country = model.ContactAddress_Country,
                            State = model.ContactAddress_State,
                            City = model.ContactAddress_City,
                            Street = model.ContactAddress_Street,
                            Zip = model.ContactAddress_Zip
                        },
                        new AddressDataObject
                        {
                            Country = model.DeliveryAddress_Country,
                            State = model.DeliveryAddress_State,
                            City = model.DeliveryAddress_City,
                            Street = model.DeliveryAddress_Street,
                            Zip = model.DeliveryAddress_Zip
                        },
                        out createStatus);
                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            return View(model);
        }

        #endregion

        #region 账户管理
        
        #endregion

        #region Helpers
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "用户名已存在，请选择另一个用户名。";

                case MembershipCreateStatus.DuplicateEmail:
                    return "电子邮件地址已存在，请选择另一个电子邮件地址。";

                case MembershipCreateStatus.InvalidPassword:
                    return "输入的密码不正确，请重新输入正确的密码。";

                case MembershipCreateStatus.InvalidEmail:
                    return "输入的电子邮件地址不正确，请输入正确的电子邮件地址。";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "输入的用户名不正确，请输入正确的用户名。";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
