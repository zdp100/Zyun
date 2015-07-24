// -----------------------------------------------------------------------
//  <copyright file="UserDto.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-08 0:31</last-date>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using OSharp.Core.Data;


namespace OSharp.Demo.Dtos.Identity
{
    public class UserDto : IAddDto, IEditDto<int>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 唯一用户名
        /// </summary>
        [Required, StringLength(100)]
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置 密码
        /// </summary>
        [StringLength(100)]
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置 电子邮箱
        /// </summary>
        [Required, StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// 获取或设置 用户昵称
        /// </summary>
        [StringLength(50)]
        public string NickName { get; set; }

        /// <summary>
        /// 获取或设置 是否锁定
        /// </summary>
        public bool IsLocked { get; set; }

        public bool IsDeleted { get; set; }
        /// <summary>
        /// 注册IP地址
        /// </summary>
        [StringLength(15)]
        public string RegistedIp { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public string RegistedTime { get; set; }
        public int RoleId { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public int Balance { get; set; }
        /// <summary>
        /// 推广返利
        /// </summary>
        public int Promote { get; set; }
    }
}