﻿// -----------------------------------------------------------------------
//  <copyright file="UserExtend.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-08 0:20</last-date>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using OSharp.Core.Data;
using System;
using OSharp.Utility.Data;
using System.ComponentModel.DataAnnotations.Schema;


namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 实体类——用户扩展信息
    /// </summary>
    [Description("认证-用户扩展信息")]
    public class UserExtend :IEntity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get;set; }

        [StringLength(18)]
        public string RegistedIp { get; set; }
        public string Tel { get; set; }
        public UserAddress Address { get; set; }
        public virtual User User { get; set; }
    }
}