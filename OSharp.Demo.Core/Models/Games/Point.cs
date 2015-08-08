using OSharp.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Games
{
    [Description("游戏-坐标信息")]
    public class Point : EntityBase<int>
    {
       // public int Id { get; set; }  默认有ID，不能重复添加
        public string Name { get; set; }
        public string Map { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int RunDistance { get; set; }
        public int FindX { get; set; }
        public int FindY { get; set; }
        public PointType PointType { get; set; }
        public virtual Game Game { get; set; }
    }
    public enum PointType
    {
        Npc,
        Monster,
        Resource
    }
}
