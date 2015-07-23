using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Dtos.Softwares
{
    public class Software
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool CanUse { get; set; }
        public bool IsForceUpdate { get; set; }
        public string CanMutliOpen { get; set; }
        public string Content { get; set; }
    }
}
