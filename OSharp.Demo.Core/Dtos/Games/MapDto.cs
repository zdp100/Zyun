using OSharp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Dtos.Games
{
    public class MapDto : IAddDto, IEditDto<int>
    {
        /// <summary>
        /// 地图的ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 地图的名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///可到的地图列表
        /// </summary>
        public ICollection<int> MapIds { get; set; }
        public int GameId { get; set; }
    }
}
