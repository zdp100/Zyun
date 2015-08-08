using OSharp.Core.Data;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 实体类--登录日志
    /// </summary>
    [Description("认证-登录日志")]
    public class LoginLog : EntityBase<int>, ICreatedTime
    {
        [Required]
        [StringLength(15)]
        public string IpAddress { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
