// -----------------------------------------------------------------------
//  <copyright file="IdentityService.User.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-03-24 17:25</last-date>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;

using OSharp.Demo.Dtos.Identity;
using OSharp.Demo.Models.Identity;
using OSharp.Utility.Data;
using OSharp.Utility.Extensions;
using System.Data.Entity.Validation;

namespace OSharp.Demo.Services
{
    public partial class IdentityService
    {


        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 用户信息查询数据集
        /// </summary>
        public IQueryable<User> Users
        {
            get { return UserRepository.Entities; }
        }

        /// <summary>
        /// 检查用户信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的用户信息编号</param>
        /// <returns>用户信息是否存在</returns>
        public bool CheckUserExists(Expression<Func<User, bool>> predicate, int id = 0)
        {
            return UserRepository.CheckExists(predicate, id);
        }

        /// <summary>
        /// 添加用户信息信息
        /// </summary>
        /// <param name="dtos">要添加的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddUsers(params UserDto[] dtos)
        {
            try
            {
              return UserRepository.Insert(dtos,
                dto =>
                {
                    if (UserRepository.CheckExists(m => m.UserName == dto.UserName ))
                    {
                        throw new Exception("已存在“{0}”用户名，不能重复添加。".FormatWith(dto.UserName));
                    }
                },
                (dto, entity) =>
                {
                    entity.Extend = new UserExtend() { RegistedIp=dto.RegistedIp};
                    return entity;
                });
            }
            catch (DbEntityValidationException ex)
            {
               return new OperationResult(OperationResultType.Error,ex.Message);
            }
            catch(Exception ex)
            {
               return new OperationResult(OperationResultType.Error, ex.Message);
            }
            
        }

        /// <summary>
        /// 更新用户信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditUsers(params UserDto[] dtos)
        {
            return UserRepository.Update(dtos);
        }

        /// <summary>
        /// 删除用户信息信息
        /// </summary>
        /// <param name="ids">要删除的用户信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteUsers(params int[] ids)
        {
            return UserRepository.Delete(ids);
        }

        /// <summary>
        /// 设置用户的角色
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="roleIds">角色编号集合</param>
        /// <returns>业务操作结果</returns>
        public OperationResult SetUserRoles(int id, int[] roleIds)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public virtual OperationResult Login(LoginInfo loginInfo)
        {
            User user = Users.SingleOrDefault(u=>u.UserName==loginInfo.Access||u.Email==loginInfo.Access);//用户名或邮箱登录
            if (user == null)
                return new OperationResult(OperationResultType.QueryNull,"指定账号的用户不存在。");
            if (user.Password != loginInfo.Password)
                return new OperationResult(OperationResultType.Error, "登录密码不正确。");
            LoginLog loginLog = new LoginLog { IpAddress = loginInfo.IpAddress, User = user };
            //To Do:写入数据库
            return new OperationResult(OperationResultType.Success,"登录成功。",user);
        }

        public void Logout()
        {
           // FormsAuthentication.SignOut();
        }
        #endregion
    }
}