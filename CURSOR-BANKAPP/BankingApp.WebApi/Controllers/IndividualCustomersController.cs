using BankingApp.Application.Features.IndividualCustomers.Commands;
using BankingApp.Application.Features.IndividualCustomers.Commands.Dtos;
using BankingApp.Application.Features.IndividualCustomers.Queries;
using BankingApp.Application.Features.IndividualCustomers.Queries.Dtos;
using BankingApp.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using BankingApp.Core.Repositories;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomersController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CreateIndividualCustomerResponseDto>> Create([FromBody] CreateIndividualCustomerRequestDto requestDto, CancellationToken cancellationToken)
        {
            var command = new CreateIndividualCustomerCommand { Request = requestDto };
            var result = await Mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetByIdIndividualCustomerQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListIndividualCustomerQuery getListIndividualCustomerQuery)
        {
            var result = await Mediator.Send(getListIndividualCustomerQuery);
            return Ok(result);
        }
    }
} 