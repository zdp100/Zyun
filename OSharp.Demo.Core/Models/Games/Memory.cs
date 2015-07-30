using OSharp.Core.Data;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Models.Games
{
    public class Memory : EntityBase<int>
    {
        public string Name { get; set; }

        public string Pointer { get; set; }

        public virtual Game Game { get; set; }
       
    }
}
