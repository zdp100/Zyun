// -----------------------------------------------------------------------
//  <copyright file="UserManager.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-06-25 15:42</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using OSharp.Core;
using OSharp.Demo.Models.Identity;


namespace OSharp.Demo.Identity
{
    /// <summary>
    /// 用户管理器
    /// </summary>
    public class UserManager : UserManager<User, int>, IDependency
    {
        public UserManager(IUserStore<User, int> store)
            : base(store)
        {
            
        }
    }
}