using OSharp.Core.Data;
using OSharp.Demo.Contracts;
using OSharp.Demo.Dtos.Games;
using OSharp.Demo.Models.Games;
using OSharp.Utility.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Services
{
    public partial class GameService:IGameContract
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(GameService));
        public IRepository<Game, int> GameRepository { protected get; set; }

        public IRepository<Map, int> MapRepository { protected get; set; }

        public IRepository<Memory, int> MemoryRepository { protected get; set; }

        public IRepository<Point, int> PointRepository { protected get; set; }











    }
}
