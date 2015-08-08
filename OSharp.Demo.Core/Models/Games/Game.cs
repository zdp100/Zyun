using OSharp.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Games
{
    [Description("游戏-游戏信息")]
    public class Game:EntityBase<int>, ICreatedTime
    { /// <summary>
        /// 初始化一个<see cref="Game"/>类型的新实例
        /// </summary>
        public Game()
        {
            Children = new List<Game>();
            Maps = new List<Map>();
            Memorys = new List<Memory>();
            Points = new List<Point>();
        }

        /// <summary>
        /// 获取或设置 名称
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 描述
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// 获取或设置 排序码
        /// </summary>
        [Range(0, 999)]
        public int SortCode { get; set; }

        /// <summary>
        /// 获取或设置 树形路径编号数组
        /// </summary>
        [NotMapped]
        public int[] TreePathIds { get { return TreePath.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); } }

        /// <summary>
        /// 获取或设置 树形路径，树链的Id以逗号分隔构成的字符串
        /// </summary>
        public string TreePath { get; set; }

        /// <summary>
        /// 获取或设置 父级组织机构信息
        /// </summary>
        public virtual Game Parent { get; set; }

        /// <summary>
        /// 获取或设置 子级组织机构信息集合
        /// </summary>
        public virtual ICollection<Game> Children { get; set; }

        /// <summary>
        /// 获取或设置 角色信息集合
        /// </summary>
        public virtual ICollection<Map> Maps { get; set; }
        /// <summary>
        /// 获取或设置 角色信息集合
        /// </summary>
        public virtual ICollection<Memory> Memorys { get; set; }
        /// <summary>
        /// 获取或设置 角色信息集合
        /// </summary>
        public virtual ICollection<Point> Points { get; set; }
        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

    }
}
