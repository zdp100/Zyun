// -----------------------------------------------------------------------
//  <copyright file="IUserManager.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-06-25 21:38</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using OSharp.Core;


namespace OSharp.Demo.Contracts
{
    /// <summary>
    /// 用户管理器
    /// </summary>
    public interface IUserManager : IDependency
    {
        /// <summary>
        /// 获取或设置 密码处理器
        /// </summary>
        IPasswordHasher PasswordHasher { get; set; }


    }
}