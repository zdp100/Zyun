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
        public IQueryable<Map> Maps
        {
            get { throw new NotImplementedException(); }
        }

        public bool CheckMapExists(System.Linq.Expressions.Expression<Func<Map, bool>> predicate, int id = 0)
        {
            throw new NotImplementedException();
        }

        public Utility.Data.OperationResult AddMaps(params MapDto[] dtos)
        {
            throw new NotImplementedException();
        }

        public Utility.Data.OperationResult EditMaps(params MapDto[] dtos)
        {
            throw new NotImplementedException();
        }

        public Utility.Data.OperationResult DeleteMaps(params int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
