using System.Data;
using System.Linq;
using Dapper;
using Sample.Entities;

namespace Sample.DataLayer
{
    public partial class TableARepository
    {
        public TableA GetTableAByStringColumnA(string searchValue, IDbConnection sqlConnection)
        {
            var results = sqlConnection.GetList<TableA>("WHERE StringColumn = @SearchValue", new { SearchValue = searchValue });
            return results.FirstOrDefault();
        }
    }
}
