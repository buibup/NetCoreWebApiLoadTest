using Dapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories.Runnings
{
    public class RunningOrderRefNoRepository : SqlRepository<string>, IRunningOrderRefNoRepository
    {
        public RunningOrderRefNoRepository(string connectionString) : base(connectionString)
        {
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<string> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<string>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetRunningOrderRefNo()
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "GetAutoIDNo";
                var result = await conn.QueryFirstOrDefaultAsync<string>(sql, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public override void InsertAsync(string entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(string entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
