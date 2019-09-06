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
                var p = new DynamicParameters();
                p.Add("@UPDATED_BY", "TEST_API");
                p.Add("@NewRunningValue", string.Empty, dbType: DbType.String, direction: ParameterDirection.Output);

                var sql = "[KMA_RUNNING_ID.SP_GET_RUNNING_MAP]";
                var result = await conn.QueryFirstOrDefaultAsync<string>(sql, p, commandType: CommandType.StoredProcedure);
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
