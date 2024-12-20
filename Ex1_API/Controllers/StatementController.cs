﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using System.Threading.Tasks;
using ApplicationService.Interfaces;
using System.Reflection;
using Refit;

namespace Ex1_API.Controllers
{
    [ApiController]
    [Route(template: "api/v1/StatementRequests")]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _statementService;

        public StatementController(IStatementService statementService)
        {
            _statementService = statementService;
        }
        // chamada do metodo get sem parametros
        [HttpGet]
        public async Task<IActionResult> GetStatements()
        {
            var statements = await _statementService.GetStatementsAsync();

            if (statements == null || !statements.Any())
            {
                return NotFound();
            }

            return Ok(statements);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StatementCreationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStatement([FromBody] StatementRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdStatment = await _statementService.CreateStatementAsync(request);
            return CreatedAtAction(nameof(GetStatements), new { id = createdStatment.Id }, createdStatment);
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetStatementsPagination
            ([FromQuery] StatementRequestPaginationParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return (BadRequest());
            }

            var paginatedStatements = await _statementService.GetStatementsPaginationAsync(parameters);

            if (paginatedStatements == null || paginatedStatements.Items == null || !paginatedStatements.Items.Any())
            {
                return NotFound();
            }

            return Ok(paginatedStatements);
        }
    }
}
