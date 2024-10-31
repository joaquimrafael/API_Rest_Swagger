using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Refit;

namespace Infrastructure.Interfaces
{
    public interface ITicketApiClient
    {
        Task<List<StatementResponse>> GetStatementsAsync();
    }
}
