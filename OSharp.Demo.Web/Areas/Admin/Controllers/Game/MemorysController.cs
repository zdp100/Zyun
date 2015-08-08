using OSharp.Demo.Contracts;
using OSharp.Demo.Dtos.Games;
using OSharp.Demo.Models.Games;
using OSharp.Utility.Filter;
using OSharp.Web.Mvc.Binders;
using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSharp.Utility.Data;
using OSharp.Utility;
using System.ComponentModel;
namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    [Description("游戏-内存管理")]
    public class MemorysController : AdminBaseController
    {

        public IGameContract IGameContract { get; set; }

        #region Ajax功能

        #region 获取数据

        //id: 组织机构编号
        [AjaxOnly]
        [Description("内存-列表数据")]
        public ActionResult GridData(int? id)
        {
            int total;
            GridRequest request = new GridRequest(Request);
            if (id.HasValue && id.Value > 0)
            {
                request.FilterGroup.Rules.Add(new FilterRule("Game.Id", id.Value));
            }
            var datas = GetQueryData<Memory, int>(IGameContract.Memorys, out total, request).Select(m => new
            {
                m.Id,
                m.Name,
                m.Pointer,
                GameId = m.Game.Id,
                GameName = m.Game.Name,
            });
            return Json(new GridData<object>(datas, total), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("内存-新增")]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<MemoryDto>))] ICollection<MemoryDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = IGameContract.AddMemorys(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("内存-编辑")]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<MemoryDto>))] ICollection<MemoryDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = IGameContract.EditMemorys(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("内存-删除")]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<int>))] ICollection<int> ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = IGameContract.DeleteMemorys(ids.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        #region 视力功能

        [Description("内存-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion
	}
}