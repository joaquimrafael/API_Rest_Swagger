using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using System.Threading.Tasks;
using ApplicationService.Interfaces;

namespace Ex1_API.Controllers
{
    [Route(template: "api/v1/StatementRequests")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _statementService;

        public StatementController(IStatementService statementService)
        {
            _statementService = statementService;
        }
        // chamada do metodo get sem parametros
        [HttpGet(Name = "GetStatements")]
        public async Task<IActionResult> GetStatement()
        {
            var statements = await _statementService.GetStatementAsync();

            /*if (statements == null || !statements.Any())
            {
                return NotFound();
            }*/

            return Ok(statements);
        }
    }
}
