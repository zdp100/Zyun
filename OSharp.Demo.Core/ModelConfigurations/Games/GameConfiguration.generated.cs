using OSharp.Core.Data.Entity;
using OSharp.Demo.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.ModelConfigurations.Games
{
    public partial class GameConfiguration : EntityConfigurationBase<Game, Int32>
    {

        public GameConfiguration()
        {
            GameConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void GameConfigurationAppend();
    }
}
