using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand: IRequest<Unit>
    {
        public UpdateLeaveAllocationDto UpdateleaveAllocationDto { get; set; }
    }
}
