using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 登录信息类
    /// </summary>
    public class LoginInfo
    {
        public string Access { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string ReturnUrl { get; set; }
    }
}
