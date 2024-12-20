﻿using System.Threading.Tasks;
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
        // injeção de dependencia da classe cliente da infra por construtor

        public async Task<List<StatementResponse>> GetStatementsAsync()
        {
            return await _ticketApiClient.GetStatementsAsync();
        }

        public async Task<StatementCreationResponse> CreateStatementAsync(StatementRequest request)
        {
            return await _ticketApiClient.CreateStatementAsync(request);
        }

        public async Task<StatementPaginationResponse> GetStatementsPaginationAsync
            (StatementRequestPaginationParameters parameters)
        {
            return await _ticketApiClient.GetStatementsPaginationAsync(parameters);
        }
    }
}

