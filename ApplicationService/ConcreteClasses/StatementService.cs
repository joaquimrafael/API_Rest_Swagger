using System.Threading.Tasks;
using Infrastructure.Interfaces;
using ApplicationService.Interfaces;
using Infrastructure.Models;

namespace ApplicationService.ConcreteClasses
{
    public class StatementService : IStatementService
    {
        private readonly ITicketApiClient _ticketApiClient;

        public StatementService(ITicketApiClient ticketApiClient)
        {
            _ticketApiClient = ticketApiClient;
        }

        public async Task<List<StatementResponse>> GetStatementAsync(int statementId)
        {
            return await _ticketApiClient.GetStatementAsync(statementId);
        }
    }
}

