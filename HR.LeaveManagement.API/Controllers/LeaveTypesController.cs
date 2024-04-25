using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HR.LeaveManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public LeaveTypesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }
    // GET: api/<LeaveTypesController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeListRequest());
        return leaveType;
    }

    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
        return Ok(leaveType);
    }

    // POST api/<LeaveTypesController>
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveType)
    {
        var command = new CreateLeaveTypeCommand { CreateLeaveTypeDto = leaveType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<LeaveTypesController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
    {
        var command = new UpdateLeaveTypeCommand { UpdateLeaveTypeDto = leaveType };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<LeaveTypesController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
    var command = new DeleteLeaveTypeCommand { Id = id };
    await _mediator.Send(command);
    return NoContent();
    }
}
