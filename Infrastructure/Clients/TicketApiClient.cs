using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Clients
{
    public class TicketApiClient : ITicketApiClient
    {
        private readonly HttpClient _httpClient;

        public TicketApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StatementResponse>> GetStatementAsync(int statementId)
        {
            var response = await _httpClient.GetAsync($"/api/v1/StatementRequests/{statementId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var statementResponses = JsonSerializer.Deserialize<List<StatementResponse>>(content, options);

            return statementResponses;
        }



    }
}
