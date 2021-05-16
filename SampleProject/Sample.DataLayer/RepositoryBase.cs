using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Sample.DataLayer
{
    public abstract class RepositoryBase<T>
    {
        public IEnumerable<T> GetAll(IDbConnection sqlConnection)
        {
            return sqlConnection.GetList<T>();
        }
    }
}
