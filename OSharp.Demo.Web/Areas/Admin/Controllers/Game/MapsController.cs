using OSharp.Demo.Contracts;
using OSharp.Utility.Filter;
using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSharp.Utility.Data;
using OSharp.Utility;
using OSharp.Demo.Models.Games;
using OSharp.Web.Mvc.Binders;
using OSharp.Demo.Dtos.Games;
using System.ComponentModel;
namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    [Description("游戏-地图管理")]
    public class MapsController : AdminBaseController
    {
        public IGameContract IGameContract { get; set; }

        #region Ajax功能

        #region 获取数据

        //id: 组织机构编号
        [AjaxOnly]
        [Description("地图-列表数据")]
        public ActionResult GridData(int? id)
        {
            int total;
            GridRequest request = new GridRequest(Request);
            if (id.HasValue && id.Value > 0)
            {
                request.FilterGroup.Rules.Add(new FilterRule("Game.Id", id.Value));
            }
            var datas = GetQueryData<Map, int>(IGameContract.Maps, out total, request).Select(m => new
            {
                m.Id,
                m.Name,
                GameId = m.Game.Id,
                GameName = m.Game.Name,
            });
            return Json(new GridData<object>(datas, total), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("地图-新增")]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<MapDto>))] ICollection<MapDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = IGameContract.AddMaps(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("地图-编辑")]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<MapDto>))] ICollection<MapDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = IGameContract.EditMaps(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("地图-删除")]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<int>))] ICollection<int> ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = IGameContract.DeleteMaps(ids.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        #region 视力功能

        [Description("地图-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion
	}
}