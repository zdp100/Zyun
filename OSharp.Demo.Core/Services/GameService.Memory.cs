using OSharp.Demo.Dtos.Games;
using OSharp.Demo.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.Services
{
    public partial class GameService
    {

        public IQueryable<Memory> Memorys
        {
            get { throw new NotImplementedException(); }
        }

        public bool CheckMemoryExists(System.Linq.Expressions.Expression<Func<Memory, bool>> predicate, int id = 0)
        {
            throw new NotImplementedException();
        }

        public Utility.Data.OperationResult AddMemorys(params MemoryDto[] dtos)
        {
            throw new NotImplementedException();
        }

        public Utility.Data.OperationResult EditMemorys(params MemoryDto[] dtos)
        {
            throw new NotImplementedException();
        }

        public Utility.Data.OperationResult DeleteMemorys(params int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
