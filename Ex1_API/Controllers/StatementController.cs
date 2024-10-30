using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using System.Threading.Tasks;
using ApplicationService.Interfaces;
using System.Reflection;

namespace Ex1_API.Controllers
{
    [ApiController]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _statementService;

        public StatementController(IStatementService statementService)
        {
            _statementService = statementService;
        }
        // chamada do metodo get sem parametros
        [HttpGet]
        [Route(template: "api/v1/StatementRequests")]
        public async Task<IActionResult> GetStatement()
        {
            var statements = await _statementService.GetStatementAsync();

            /*if (statements == null || !statements.Any())
            {
                return NotFound();
            }*/

            return Ok(statements);
        }

        [HttpPost]
        [Route(template: "api/v1/StatementRequests")]
        public StatusCodeResult Post()
        {
            return Ok();
        }
    }
}
