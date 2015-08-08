using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSharp.Demo.Contracts;
using OSharp.Demo.Dtos.Identity;
using OSharp.Demo.Models.Identity;
using OSharp.Utility;
using OSharp.Utility.Data;
using OSharp.Utility.Extensions;
using OSharp.Utility.Filter;
using OSharp.Web.Mvc.Binders;
using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;

using OSharp.Demo.Models.Games;
using OSharp.Demo.Dtos.Games;
using System.ComponentModel;
namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    [Description("游戏-坐标管理")]
    public class PointsController : AdminBaseController
    {

        public IGameContract IGameContract { get; set; }

        #region Ajax功能

        #region 获取数据


        [AjaxOnly]
        [Description("坐标-列表数据")]
        public ActionResult GridData(int? id)
        {
            int total;
            GridRequest request = new GridRequest(Request);
            if (id.HasValue && id.Value > 0)
            {
                request.FilterGroup.Rules.Add(new FilterRule("Game.Id", id.Value));
            }
            var datas = GetQueryData<Point, int>(IGameContract.Points, out total, request).Select(m => new
            {
                m.Id,
                m.Name,
                m.X,
                m.Y,
                m.FindX,
                m.FindY,
                m.RunDistance,
                m.Map,
                PointType=m.PointType,
                GameId = m.Game.Id,
                GameName = m.Game.Name,
            });
            return Json(new GridData<object>(datas, total), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("坐标-新增")]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<PointDto>))] ICollection<PointDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = IGameContract.AddPoints(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("坐标-编辑")]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<PointDto>))] ICollection<PointDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = IGameContract.EditPoints(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("坐标-删除")]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<int>))] ICollection<int> ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = IGameContract.DeletePoints(ids.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        #region 视力功能

        [Description("坐标-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion
	}
}