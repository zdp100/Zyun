using OSharp.Core.Data;
using OSharp.Demo.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Dtos.Games
{
    public class MemoryDto : IAddDto, IEditDto<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Pointer { get; set; }

        public int GameId { get; set; }
        
    }
}
