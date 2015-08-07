﻿// -----------------------------------------------------------------------
//  <copyright file="Member.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-07 23:33</last-date>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using OSharp.Core.Identity.Models;


namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 实体类——用户信息
    /// </summary>
    [Description("认证-用户信息")]
    public class User : UserBase<int>
    {
        /// <summary>
        /// 获取或设置 是否锁定
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 获取或设置 用户扩展信息
        /// </summary>
        public virtual UserExtend Extend { get; set; }
        /// <summary>
        /// 获取或设置 用户拥有的角色信息集合
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
        /// <summary>
        /// 获取或设置 用户登录日志集合
        /// </summary>
        public virtual ICollection<LoginLog> LoginLogs { get; set; }
    }
}