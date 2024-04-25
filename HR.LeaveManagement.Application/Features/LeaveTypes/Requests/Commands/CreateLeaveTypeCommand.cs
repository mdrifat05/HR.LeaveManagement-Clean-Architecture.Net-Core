using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;

public class CreateLeaveTypeCommand: IRequest<BaseCommandResponse>
{
    public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
}
