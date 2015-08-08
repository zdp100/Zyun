using OSharp.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 用户地址信息
    /// </summary>
     [Description("认证-用户地址")]
    public class UserAddress:IEntity<int>
    {
        [NotMapped]
        public int Id { get; set; }

        [StringLength(10)]
        public string Province { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        public string County { get; set; }

        [StringLength(60,MinimumLength=5)]
        public string Street { get; set; }
    }
}
