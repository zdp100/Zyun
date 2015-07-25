using OSharp.Core.Data;
using OSharp.Demo.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Dtos.Games
{
    public class PointDto : IAddDto, IEditDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int RunDistance { get; set; }
        public int FindX { get; set; }
        public int FindY { get; set; }
        public PointType PointType { get; set; }

        public int GameId { get; set; }
       
    }
}
