using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Dtos.Systems
{
    public class LoginLogDto
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string IP { get; set; }
    }
}
