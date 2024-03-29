﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IRunningOrderRefNoRepository : IGenericRepository<string>
    {
        Task<string> GetRunningOrderRefNo();
    }
}
