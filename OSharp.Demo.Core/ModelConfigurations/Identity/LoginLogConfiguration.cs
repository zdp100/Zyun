using OSharp.Core.Data.Entity;
using OSharp.Demo.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.ModelConfigurations.Identity
{
    public class LoginLogConfiguration : EntityConfigurationBase<LoginLog, Int32>
    {
        /// <summary>
        /// 配置N:1关系
        /// </summary>
        public LoginLogConfiguration()
        {
            HasRequired(m=>m.User).WithMany(n=>n.LoginLogs);
        }
    }
}
