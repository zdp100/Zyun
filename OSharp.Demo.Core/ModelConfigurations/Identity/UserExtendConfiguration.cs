﻿// -----------------------------------------------------------------------
//  <copyright file="UserExtendConfiguration.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-03-24 17:04</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSharp.Demo.ModelConfigurations.Identity
{
    public partial class UserExtendConfiguration
    {
        /// <summary>
        /// 配置用户扩展信息与用户信息0:1关系
        /// </summary>
        partial void UserExtendConfigurationAppend()
        {
            HasRequired(m => m.User).WithOptional(n => n.Extend);
        }
    }
}