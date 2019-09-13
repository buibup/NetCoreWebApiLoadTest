using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface IRunningOrderRefNoRepository : IGenericRepository<string>
    {
        Task<string> GetRunningOrderRefNo();
    }
}
