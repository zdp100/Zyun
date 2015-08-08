using Newtonsoft.Json;
using OSharp.Demo.Contracts;
using OSharp.Demo.Models.Games;
using OSharp.Utility.Data;
using OSharp.Web.Mvc.Binders;
using OSharp.Web.Mvc.Security;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSharp.Demo.Dtos.Games;
using OSharp.Web.UI;
using OSharp.Utility;
using System.ComponentModel;
namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
     [Description("游戏-游戏管理")]
    public class GamesController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 身份认证业务对象
        /// </summary>
        public IGameContract IGameContract { get; set; }

        #region 视力功能

        [Description("游戏-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion

        private class GameView
        {
            public GameView(Game org)
            {
                Id = org.Id;
                Name = org.Name;
                Remark = org.Remark;
                SortCode = org.SortCode;
                CreatedTime = org.CreatedTime;
                children = new List<GameView>();
            }

            public int Id { get; set; }

            public string Name { get; set; }

            public string Remark { get; set; }

            public int SortCode { get; set; }

            public DateTime CreatedTime { get; set; }

            public ICollection<GameView> children { get; set; }
        }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("游戏-列表数据")]
        public ActionResult GridData()
        {
            Func<Game, ICollection<Game>, GameView> getGameView = null;
            getGameView = (org, source) =>
            {
                GameView view = new GameView(org);
                List<Game> children = source.Where(m => m.TreePathIds.Length == org.TreePathIds.Length + 1
                    && m.TreePath.StartsWith(org.TreePath)).ToList();
                foreach (Game child in children)
                {
                    GameView childView = getGameView(child, source);
                    view.children.Add(childView);
                }
                return view;
            };
            List<Game> roots = IGameContract.Games.Where(m => m.Parent == null).OrderBy(m => m.SortCode).ToList();
            List<GameView> datas = (from root in roots
                                    let source = IGameContract.Games.Where(m => m.TreePath.StartsWith(root.TreePath)).ToList()
                                    select getGameView(root, source)).ToList();
            return Json(datas, JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        [Description("游戏-节点数据")]
        public ActionResult NodeData()
        {
            Func<Game, object> getNodeData = null;
            getNodeData = org =>
            {
                dynamic node = new ExpandoObject();
                node.id = org.Id;
                node.text = org.Name;
                node.children = new List<dynamic>();
                var children = org.Children.OrderBy(m => m.SortCode).ToList();
                foreach (var child in children)
                {
                    node.children.Add(getNodeData(child));
                }
                return node;
            };
            List<Game> roots = IGameContract.Games.Where(m => m.Parent == null).OrderBy(m => m.SortCode).ToList();
            List<object> nodes = roots.Select(getNodeData).ToList();
            string json = JsonConvert.SerializeObject(nodes);
            return Content(json, "application/json");
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("游戏-新增")]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<GameDto>))] GameDto dto)
        {
            dto.CheckNotNull("dto");
            OperationResult result = IGameContract.AddGames(dto);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("游戏-编辑")]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<GameDto>))] GameDto dto)
        {
            dto.CheckNotNull("dto");
            OperationResult result = IGameContract.EditGames(dto);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("游戏-删除")]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<int>))] ICollection<int> ids)
        {
            ids.CheckNotNull("ids");
            foreach(var id in ids)
            {
                id.CheckGreaterThan("id", 0);
            }
            OperationResult result = IGameContract.DeleteGames(ids.ToArray());
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion
	}
}