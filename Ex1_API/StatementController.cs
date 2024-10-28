using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using System.Threading.Tasks;
using ApplicationService.Interfaces;

namespace Ex1_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _statementService;

        public StatementController (IStatementService statementService)
        {
            _statementService = statementService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatement(int id)
        {
            var statements = await _statementService.GetStatementAsync(id);

            if (statements == null || !statements.Any())
            {
                return NotFound();
            }

            return Ok(statements);
        }
    }
}
