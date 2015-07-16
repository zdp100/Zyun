// -----------------------------------------------------------------------
//  <copyright file="FunctionsController.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-07-15 1:03</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSharp.Core.Security;
using OSharp.Demo.Contracts;
using OSharp.Demo.Dtos.Security;
using OSharp.SiteBase;
using OSharp.SiteBase.Security;
using OSharp.Utility;
using OSharp.Utility.Data;
using OSharp.Web.Mvc.Binders;
using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;


namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    [Description("管理-功能信息")]
    public class FunctionsController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 安全业务对象
        /// </summary>
        public ISecurityContract SecurityContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("功能-列表数据")]
        public ActionResult GridData()
        {
            int total;
            GridRequest request = new GridRequest(Request);
            if (request.PageCondition.SortConditions.Length == 0)
            {
                request.PageCondition.SortConditions = new[]
                {
                    new SortCondition("Area"),
                    new SortCondition("Controller"), 
                    new SortCondition("Name")
                };
            }
            var datas = GetQueryData<Function, Guid>(SecurityContract.Functions, out total, request)
                .Select(m => new
                {
                    m.Id,
                    m.Name,
                    m.Url,
                    m.FunctionType,
                    m.OperateLogEnabled,
                    m.DataLogEnabled,
                    m.Area,
                    m.Controller,
                    m.Action,
                    m.IsController,
                    m.IsAjax,
                    m.IsChild,
                    m.IsLocked,
                    m.IsTypeChanged,
                    m.IsCustom
                }).Select(m => new
                {
                    m.Id,
                    m.Name,
                    m.Url,
                    m.FunctionType,
                    m.OperateLogEnabled,
                    m.DataLogEnabled,
                    m.Area,
                    m.Controller,
                    m.Action,
                    ModuleName = m.Area + "-" + m.Controller,
                    m.IsController,
                    m.IsAjax,
                    m.IsChild,
                    m.IsLocked,
                    m.IsTypeChanged,
                    m.IsCustom
                }).ToList();
            return Json(new GridData<object>(datas, total), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("功能-新增")]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<FunctionDto>))] ICollection<FunctionDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = SecurityContract.AddFunctions(dtos.ToArray());
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("功能-编辑")]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<FunctionDto>))] ICollection<FunctionDto> dtos)
        {
            dtos.CheckNotNull("dtos" );
            OperationResult result = SecurityContract.EditFunctions(dtos.ToArray());
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("功能-删除")]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<Guid>))] ICollection<Guid> ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = SecurityContract.DeleteFunctions(ids.ToArray());
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion

        #region 视图功能

        [Description("功能-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion

    }
}