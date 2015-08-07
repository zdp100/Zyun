// -----------------------------------------------------------------------
//  <copyright file="Role.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-08 0:24</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;

using OSharp.Core.Identity.Models;


namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 实体类——角色信息
    /// </summary>
    [Description("认证-角色信息")]
    public class Role : RoleBase<int>
    {
        /// <summary>
        /// 获取或设置 是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 获取或设置 是否锁定
        /// </summary>
        public bool IsLocked { get; set; }

        public RoleType RoleType { get; set; }

        public int RoleTypeNum { get; set; }

        public virtual ICollection<User> Users { get; set; }
        /// <summary>
        /// 获取或设置 角色所属组织机构
        /// </summary>
        public virtual Organization Organization { get; set; }
    }
}