using OSharp.Demo.Dtos.Games;
using OSharp.Demo.Models.Games;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OSharp.Utility.Extensions;

namespace OSharp.Demo.Services
{
    public partial class GameService
    {
        #region Implementation of IIdentityContract

        public IQueryable<Point> Points
        {
            get { return PointRepository.Entities; }
        }

        public bool CheckPointExists(Expression<Func<Point, bool>> predicate, int id = 0)
        {
            return PointRepository.CheckExists(predicate, id);
        }

        public OperationResult AddPoints(params PointDto[] dtos)
        {
            return PointRepository.Insert(dtos,
                dto =>
                {
                    if (PointRepository.CheckExists(m => m.Name == dto.Name && m.Game.Id == dto.GameId))
                    {
                        throw new Exception("同节点中名称为“{0}”的坐标已存在，不能重复添加。".FormatWith(dto.Name));
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

 
        public OperationResult EditPoints(params PointDto[] dtos)
        {
            return PointRepository.Update(dtos,
                dto =>
                {
                    if (PointRepository.CheckExists(m => m.Name == dto.Name && m.Game.Id == dto.GameId, dto.Id))
                    {
                        throw new Exception("同节点中名称为“{0}”的坐标已存在，不能重复添加。".FormatWith(dto.Name));
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
        public OperationResult DeletePoints(params int[] ids)
        {
            return PointRepository.Delete(ids);
        }

        #endregion
    }
}
