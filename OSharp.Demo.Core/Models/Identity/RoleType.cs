using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Identity
{
    public enum RoleType
    {
        [Description("用户角色")]
        User=0,
        [Description("管理角色")]
        Admin=1
    }
}
