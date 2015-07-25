// -----------------------------------------------------------------------
//  <copyright file="HomeController.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-02-19 17:43</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSharp.Demo.Web.ViewModels;
using OSharp.Utility.Logging;
using OSharp.Web.Mvc.Security;


namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    [Description("管理-后台")]
    public class HomeController : Controller
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HomeController));

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("管理-菜单数据")]
        public ActionResult GetMenuData()
        {
            List<TreeNode> nodes = new List<TreeNode>()
            {
                new TreeNode()
                {
                    Text = "权限",
                    IconCls = "pic_26",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "用户管理", IconCls = "pic_5", Url = Url.Action("Index", "Users") },
                        new TreeNode() { Text = "角色管理", IconCls = "pic_198", Url = Url.Action("Index", "Roles") },
                        new TreeNode() { Text = "组织机构管理", IconCls = "pic_93", Url = Url.Action("Index", "Organizations") },
                        new TreeNode() { Text = "功能管理", IconCls = "pic_94", Url = Url.Action("Index", "Functions") },
                        new TreeNode() { Text = "实体数据管理", IconCls = "pic_95", Url = Url.Action("Index", "EntityInfos") },
                    }
                },
                  new TreeNode()
                {
                    Text = "用户",
                    IconCls = "pic_27",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "用户管理", IconCls = "pic_5", Url = Url.Action("Index", "Users") },
                        new TreeNode() { Text = "游戏角色管理", IconCls = "pic_198", Url = Url.Action("Index", "Roles") },
                        new TreeNode() { Text = "在线用户管理", IconCls = "pic_111", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "充值卡管理", IconCls = "pic_31", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "充值卡激活记录", IconCls = "pic_32", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "支付宝充值记录", IconCls = "pic_33", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "余额管理", IconCls = "pic_100", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "余额收支明细", IconCls = "pic_34", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "功能权限", IconCls = "pic_100", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "功能权限日志", IconCls = "pic_35", Url = Url.Action("SystemLogs", "Logging") }
                    }
                },
                  new TreeNode()
                {
                    Text = "游戏",
                    IconCls = "pic_36",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "游戏管理", IconCls = "pic_37", Url = Url.Action("Index", "Games") },
                        new TreeNode() { Text = "内存地址管理", IconCls = "pic_38", Url = Url.Action("Index", "Memorys") },
                        new TreeNode() { Text = "游戏地图管理", IconCls = "pic_39", Url = Url.Action("Index", "Maps") },
                        new TreeNode() { Text = "游戏坐标管理", IconCls = "pic_40", Url = Url.Action("Index", "Points") },
                        new TreeNode() { Text = "游戏大区管理", IconCls = "pic_41", Url = Url.Action("Index", "Areas") },
                        new TreeNode() { Text = "游戏区服管理", IconCls = "pic_42", Url = Url.Action("Index", "Servers") }
                    }
                },
                  new TreeNode()
                {
                    Text = "软件",
                    IconCls = "pic_46",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "软件管理", IconCls = "pic_43", Url = Url.Action("OperateLogs", "Logging") },
                        new TreeNode() { Text = "功能管理", IconCls = "pic_44", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "版本管理", IconCls = "pic_45", Url = Url.Action("SystemLogs", "Logging") }
                    }
                },
                 new TreeNode()
                {
                    Text = "信息",
                    IconCls = "pic_51",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "数据管理", IconCls = "pic_47", Url = Url.Action("OperateLogs", "Logging") },
                        new TreeNode()
                        { 
                            Text = "站内消息", 
                            IconCls = "pic_50", 
                            Children = new List<TreeNode>()
                            {
                                 new TreeNode() { Text = "系统消息", IconCls = "pic_48", Url = Url.Action("OperateLogs", "Logging") }, 
                                 new TreeNode() { Text = "公共消息", IconCls = "pic_49", Url = Url.Action("OperateLogs", "Logging") }
                            }
                        }
                    }
                },
                new TreeNode()
                {
                    Text = "系统",
                    IconCls = "pic_52",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "操作日志", IconCls = "pic_53", Url = Url.Action("OperateLogs", "Logging") },
                        new TreeNode() { Text = "系统日志", IconCls = "pic_54", Url = Url.Action("SystemLogs", "Logging") },
                        new TreeNode() { Text = "登陆日志", IconCls = "pic_55", Url = Url.Action("LoginLogs", "Logging") }
                    }
                }

            };

            Action<ICollection<TreeNode>> action = list =>
            {
                foreach (TreeNode node in list)
                {
                    node.Id = "node" + node.Text;
                }
            };

            foreach (TreeNode node in nodes)
            {
                node.Id = "node" + node.Text;
                if (node.Children != null && node.Children.Count > 0)
                {
                    action(node.Children);
                }
            }

            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        [Description("管理-首页")]
        public ActionResult Index()
        {
            Logger.Debug("访问后台管理首页");
            return View();
        }

        [Description("管理-欢迎页")]
        public ActionResult Welcome()
        {
            return View();
        }
    }
}