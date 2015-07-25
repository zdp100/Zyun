using OSharp.Core.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.ModelConfigurations.Games
{
    public partial class GameConfiguration
    {
        /// <summary>
        /// 获取 相关上下文类型
        /// </summary>
        public override Type DbContextType
        {
            get { return typeof(DefaultDbContext); }
        }

        partial void GameConfigurationAppend()
        {
          
            HasOptional(m => m.Parent).WithMany(n => n.Children);
        }
    }
}
