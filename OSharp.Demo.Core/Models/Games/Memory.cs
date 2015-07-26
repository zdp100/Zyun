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

        public string Offset { get; set; }

        public virtual Memory BaseAddress { get; set; }

        public virtual Game Game { get; set; }
       
        public override string ToString()
        {
            string result = Offset;
            if (BaseAddress != null)
            {
                result = BaseAddress.Name == "游戏基址"
                    ? AnyRadixConvert._10To16(AnyRadixConvert._16To10(BaseAddress.Offset) + AnyRadixConvert._16To10(Offset))
                    : string.Format("[{0}]+{1}", BaseAddress.ToString(), Offset);
            }
            return string.IsNullOrEmpty(result) ? "0" : result.StartsWith("[") || result[0] == '0' ? result : '0' + result;
        }
    }
}
