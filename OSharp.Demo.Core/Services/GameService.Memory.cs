using OSharp.Demo.Dtos.Games;
using OSharp.Demo.Models.Games;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSharp.Utility.Extensions;

namespace OSharp.Demo.Services
{
    public partial class GameService
    {

        public IQueryable<Memory> Memorys
        {
            get { return MemoryRepository.Entities; }
        }

        public bool CheckMemoryExists(System.Linq.Expressions.Expression<Func<Memory, bool>> predicate, int id = 0)
        {
            return MemoryRepository.CheckExists(predicate, id);
        }

        public OperationResult AddMemorys(params MemoryDto[] dtos)
        {
            return MemoryRepository.Insert(dtos,
               dto =>
               {
                   if (MemoryRepository.CheckExists(m => m.Name == dto.Name && m.Game.Id == dto.GameId))
                   {
                       throw new Exception("同节点中名称为“{0}”的内存地址已存在，不能重复添加。".FormatWith(dto.Name));
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

        public OperationResult EditMemorys(params MemoryDto[] dtos)
        {
            return MemoryRepository.Update(dtos,
               dto =>
               {
                   if (MemoryRepository.CheckExists(m => m.Name == dto.Name && m.Game.Id == dto.GameId, dto.Id))
                   {
                       throw new Exception("同节点中名称为“{0}”的内存地址已存在，不能重复添加。".FormatWith(dto.Name));
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

        public OperationResult DeleteMemorys(params int[] ids)
        {
            return MemoryRepository.Delete(ids);
        }
    }
}
