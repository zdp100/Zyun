using OSharp.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Games
{
    [Description("游戏-地图信息")]
    public class Map : EntityBase<int>
    {
        /// <summary>
        /// 地图的名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 可到地图列表
        /// </summary>
        public ICollection<Map> Maps { get; set; }
        public Game Game { get; set; }
    }
}
