// -----------------------------------------------------------------------
//  <copyright file="UserValidator.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-06-26 1:49</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSharp.Core;
using OSharp.Core.Identity;
using OSharp.Demo.Models.Identity;


namespace OSharp.Demo.Identity
{
    public class UserValidator : UserValidator<User, int>
    { }
}