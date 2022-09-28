using Talabeya_Task.Application.Tickets.Commands.CreateTicket;
using Talabeya_Task.Application.Tickets.Commands.DeleteTicket;
using Talabeya_Task.Application.Tickets.Commands.UpdateTicket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talabeya_Task.Application.Tickets.Queries.GetTicketsWithPagination;
using Talabeya_Task.Application.Common.Models;

namespace Talabeya_Task.WebUI.Controllers;

public class TicketsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TicketBriefDto>>> Get([FromQuery] GetTicketsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTicketCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult> Update(HandleTicketCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTicketCommand(id));

        return NoContent();
    }
}
