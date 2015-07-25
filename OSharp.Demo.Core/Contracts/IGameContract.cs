using OSharp.Core;
using OSharp.Demo.Dtos.Games;
using OSharp.Demo.Models.Games;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Contracts
{
    public interface IGameContract : IDependency
    {
        #region 游戏信息业务
        IQueryable<Game> Games { get; }
        bool CheckGameExists(Expression<Func<Game, bool>> predicate, int id = 0);
        OperationResult AddGames(params GameDto[] dtos);
        OperationResult EditGames(params GameDto[] dtos);
        OperationResult DeleteGames(params int[] ids);
        #endregion
      
        #region 坐标信息业务
        IQueryable<Point> Points { get; }
        bool CheckPointExists(Expression<Func<Point, bool>> predicate, int id = 0);
        OperationResult AddPoints(params PointDto[] dtos);
        OperationResult EditPoints(params PointDto[] dtos);
        OperationResult DeletePoints(params int[] ids);

        #endregion

        #region 内存信息业务
        IQueryable<Memory> Memorys { get; }
        bool CheckMemoryExists(Expression<Func<Memory, bool>> predicate, int id = 0);
        OperationResult AddMemorys(params MemoryDto[] dtos);
        OperationResult EditMemorys(params MemoryDto[] dtos);
        OperationResult DeleteMemorys(params int[] ids);

        #endregion

        #region 地图信息业务
        IQueryable<Map> Maps { get; }
        bool CheckMapExists(Expression<Func<Map, bool>> predicate, int id = 0);
        OperationResult AddMaps(params MapDto[] dtos);
        OperationResult EditMaps(params MapDto[] dtos);
        OperationResult DeleteMaps(params int[] ids);

        #endregion
    }
}
