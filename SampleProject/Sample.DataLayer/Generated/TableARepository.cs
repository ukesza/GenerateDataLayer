using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

using Sample.Entities;
 
namespace Sample.DataLayer
{
    /// <summary>
    /// Data Repository for a TableA backed by TableA.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// If you want to add a method, create a partial class to extend this one
    /// </summary>
	public partial class TableARepository : RepositoryBase<TableA>
    {
        public TableA GetTableA(int tableaId, IDbConnection sqlConnection)
        {
            return sqlConnection.Get<TableA>(tableaId);
        }
        public TableA SaveTableA(TableA tablea, IDbConnection sqlConnection)
        {
            var id = tablea.Id;
            if (id <= 0)
            {
                id = sqlConnection.Insert<int, TableA>(tablea);
            }
            else
            {
                var affectedCount = sqlConnection.Update(tablea);

                if (affectedCount < 1)
                {
                    throw new ApplicationException($"Incorrect number of rows affected during TableA update. Expected 1 but was {affectedCount}");
                }
            }
            
            return sqlConnection.Get<TableA>(id);
        }
    }
}      
