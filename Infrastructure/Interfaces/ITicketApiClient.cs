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
        [Get(("/api/v1/StatementRequests"))]
        Task<List<StatementResponse>> GetStatementsAsync();

        [Post("/api/v1/StatementRequests")]
        Task<StatementCreationResponse> CreateStatementAsync([Body] StatementRequest request);
    }
}
