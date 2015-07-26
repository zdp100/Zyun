using OSharp.Demo.Dtos.Games;
using OSharp.Demo.Models.Games;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSharp.Utility.Extensions;
using OSharp.Utility;
using System.Linq.Expressions;

namespace OSharp.Demo.Services
{
    public partial class GameService
    {
        public IQueryable<Map> Maps
        {
            get { return MapRepository.Entities; }
        }

        public bool CheckMapExists(Expression<Func<Map, bool>> predicate, int id = 0)
        {
            return MapRepository.CheckExists(predicate, id);
        }

        public OperationResult AddMaps(params MapDto[] dtos)
        {
            return MapRepository.Insert(dtos,
               dto =>
               {
                   if (MapRepository.CheckExists(m => m.Name == dto.Name && m.Game.Id == dto.GameId))
                   {
                       throw new Exception("同节点中名称为“{0}”的地图已存在，不能重复添加。".FormatWith(dto.Name));
                   }
               },
               (dto, entity) =>
               {
                   Game game = GameRepository.GetByKey(dto.GameId);
                   if (game == null)
                   {
                       throw new Exception("要加入的节点不存在。");
                   }
                   entity.Game = game;
                   return entity;
               });
        }

        public OperationResult EditMaps(params MapDto[] dtos)
        {
            return MapRepository.Update(dtos,
               dto =>
               {
                   if (MapRepository.CheckExists(m => m.Name == dto.Name && m.Game.Id == dto.GameId, dto.Id))
                   {
                       throw new Exception("同节点中名称为“{0}”的地图已存在，不能重复添加。".FormatWith(dto.Name));
                   }
               },
               (dto, entity) =>
               {
                   Game game = GameRepository.GetByKey(dto.GameId);
                   if (game == null)
                   {
                       throw new Exception("要加入的节点不存在。");
                   }
                   entity.Game = game;
                   //entity.BaseAddress=
                   return entity;
               });
        }

        public OperationResult DeleteMaps(params int[] ids)
        {
            return MapRepository.Delete(ids);
        }
    }
}
