using OSharp.Demo.Dtos.Games;
using OSharp.Demo.Models.Games;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OSharp.Utility;
using OSharp.Utility.Extensions;

namespace OSharp.Demo.Services
{
    public partial class GameService
    {
        public IQueryable<Game> Games
        {
            get { return GameRepository.Entities; }
        }

        public bool CheckGameExists(Expression<Func<Game, bool>> predicate, int id = 0)
        {
            return GameRepository.CheckExists(predicate, id);
        }

        public OperationResult DeleteGames(params int[] ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = GameRepository.Delete(ids,
                entity =>
                {
                    if (entity.Children.Any())
                    {
                        throw new Exception("节点“{0}”的子级不为空，不能删除。".FormatWith(entity.Name));
                    }
                });
            return result;
        }


        public OperationResult AddGames(params GameDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            List<Game> games = new List<Game>();
            OperationResult result = GameRepository.Insert(dtos,
                dto =>
                {
                    if (GameRepository.CheckExists(m => m.Name == dto.Name))
                    {
                        throw new Exception("名称为“{0}”的节点已存在，不能重复添加。".FormatWith(dto.Name));
                    }
                },
                (dto, entity) =>
                {
                    if (dto.ParentId.HasValue && dto.ParentId.Value > 0)
                    {
                        Game parent = GameRepository.GetByKey(dto.ParentId.Value);
                        if (parent == null)
                        {
                            throw new Exception("指定父节点不存在。");
                        }
                        entity.Parent = parent;
                    }
                    games.Add(entity);
                    return entity;
                });
            if (result.ResultType == OperationResultType.Success)
            {
                int[] ids = games.Select(m => m.Id).ToArray();
                RefreshOrganizationsTreePath(ids);
            }
            return result;
        }

        public OperationResult EditGames(params GameDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            List<Game> games = new List<Game>();
            OperationResult result = GameRepository.Update(dtos,
                dto =>
                {
                    if (GameRepository.CheckExists(m => m.Name == dto.Name, dto.Id))
                    {
                        throw new Exception("名称为“{0}”的节点已存在，不能重复添加。".FormatWith(dto.Name));
                    }
                },
                (dto, entity) =>
                {
                    if (!dto.ParentId.HasValue || dto.ParentId == 0)
                    {
                        entity.Parent = null;
                    }
                    else if (entity.Parent != null && entity.Parent.Id != dto.ParentId)
                    {
                        Game parent = GameRepository.GetByKey(dto.Id);
                        if (parent == null)
                        {
                            throw new Exception("指定父节点不存在。");
                        }
                        entity.Parent = parent;
                    }
                    games.Add(entity);
                    return entity;
                });
            if (result.ResultType == OperationResultType.Success)
            {
                int[] ids = games.Select(m => m.Id).ToArray();
                RefreshOrganizationsTreePath(ids);
            }
            return result;
        }
        #region 私有方法+void RefreshOrganizationsTreePath(params int[] ids)

        private void RefreshOrganizationsTreePath(params int[] ids)
        {
            if (ids.Length == 0)
            {
                return;
            }
            List<Game> games = GameRepository.GetInclude(m => m.Parent).Where(m => ids.Contains(m.Id)).ToList();
            GameRepository.UnitOfWork.TransactionEnabled = true;
            foreach (Game game in games)
            {
                game.TreePath = game.Parent == null
                    ? game.Id.ToString()
                    : game.Parent.TreePathIds.Union(new[] { game.Id }).ExpandAndToString();
                GameRepository.Update(game);
            }
            GameRepository.UnitOfWork.SaveChanges();
        }

        #endregion
    }
}
