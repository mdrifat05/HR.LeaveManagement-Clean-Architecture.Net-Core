using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using HR.LeaveManagement.Application.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand: IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
    }
}
