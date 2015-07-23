using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Dtos.Systems
{
    public class SystemLog
    {
        public Guid Id { get; set; }
        public string Detail { get; set; }
        public DateTime Time { get; set; }
    }
}
