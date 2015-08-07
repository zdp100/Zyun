// -----------------------------------------------------------------------
//  <copyright file="UsersController.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>最后修改人</last-editor>
//  <last-date>2015-01-09 20:30</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;
using OSharp.Demo.Contracts;
using OSharp.Demo.Dtos.Identity;
using OSharp.Web.Mvc.Binders;
using OSharp.Utility.Data;
using OSharp.Utility;
using OSharp.Demo.Models.Identity;

namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    [Description("管理-用户")]
    public class UsersController : Controller
    {
        /// <summary>
        /// 获取或设置 身份认证业务对象
        /// </summary>
        public IIdentityContract IdentityContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("用户-列表数据")]
        public ActionResult GridData()
        {
            var datas=IdentityContract.Users.ToList();
            return Json(new GridData<object>(datas, datas.Count), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        #region 视图功能

        [Description("用户-列表")]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region 功能方法
 
        
        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        private string GetIP()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return ip;
        }

        [HttpPost]
        [AjaxOnly]
        [Description("用户-新增")]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<UserDto>))] ICollection<UserDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            foreach (var ud in dtos)
            {
                ud.RegistedIp = GetIP();
            }
            OperationResult result = IdentityContract.AddUsers(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("用户-编辑")]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<UserDto>))] ICollection<UserDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = IdentityContract.EditUsers(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("用户-删除")]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<int>))] ICollection<int> ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = IdentityContract.DeleteUsers(ids.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login()
        {
            string returnUrl = Request.Params["returnUrl"];
            returnUrl = returnUrl ?? Url.Action("Index", "Home", new { area = "" });
             LoginInfo info = new LoginInfo
             {
                 ReturnUrl = returnUrl
             };
             return View(info);

        }
        [HttpPost]
        public ActionResult Login(LoginInfo info)
        {
            try
            {
                OperationResult result = IdentityContract.Login(info);
               
                if(result.ResultType==OperationResultType.Success)
                {
                    return Redirect(info.ReturnUrl);
                }
                return View(info);
            }catch(Exception e)
            {
                return View(info);
            }
           
        }
     
        public ActionResult Logout()
        {
            string returnUrl = Request.Params["returnUrl"];
            returnUrl = returnUrl ?? Url.Action("Index", "Home", new { area = "" });
             if (User.Identity.IsAuthenticated)
             {
                IdentityContract.Logout();
             }
             return Redirect(returnUrl);

        }
        #endregion
    }
}