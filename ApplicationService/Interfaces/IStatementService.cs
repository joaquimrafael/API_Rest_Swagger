﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace ApplicationService.Interfaces
{
    public interface IStatementService
    {
        Task<List<StatementResponse>> GetStatementAsync();
    }
}
