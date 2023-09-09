using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand: IRequest<Unit>
    {
        public LeaveTypeDto UpdateLeaveTypeDto { get; set; }
    }
}
