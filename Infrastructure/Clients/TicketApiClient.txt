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
        // crio o cliente que vai fazer a requisição get ao servidor

        public async Task<List<StatementResponse>> GetStatementsAsync()
        {
            var response = await _httpClient.GetAsync($"/api/v1/StatementRequests");
            // navego ate o endpoint desejado
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(); // leio o conteudo

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // faço um serializador Json que n é sensivel a case

            var statementResponses = JsonSerializer.Deserialize<List<StatementResponse>>(content, options);
            // recebo a resposta e a retorno
            return statementResponses;
        }



    }
}
