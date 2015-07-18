// -----------------------------------------------------------------------
//  <copyright file="EntityInfosController.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-07-15 2:06</last-date>
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
using OSharp.Utility;
using OSharp.Utility.Data;
using OSharp.Web.Mvc.Binders;
using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;


namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    [Description("管理-实体数据信息")]
    public class EntityInfosController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 安全业务对象
        /// </summary>
        public ISecurityContract SecurityContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("实体数据-列表数据")]
        public ActionResult GridData()
        {
            int total;
            GridRequest request = new GridRequest(Request);
            if (request.PageCondition.SortConditions.Length == 0)
            {
                request.PageCondition.SortConditions = new[]
                {
                    new SortCondition("ClassName")
                };
            }
            var datas = GetQueryData<EntityInfo, Guid>(SecurityContract.EntityInfos, out total, request).Select(m => new
            {
                m.Id,
                m.Name,
                m.ClassName,
                m.DataLogEnabled
            }).ToList();
            return Json(new GridData<object>(datas, total), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("实体数据-编辑")]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<EntityInfoDto>))] ICollection<EntityInfoDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = SecurityContract.EditEntityInfos(dtos.ToArray());
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion

        #region 视图功能

        #region Overrides of AdminBaseController

        [Description("实体数据-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion

        #endregion

    }
}