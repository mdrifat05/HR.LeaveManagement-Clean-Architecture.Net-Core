using HR.LeaveManagement.Application.DTOs.LeaveRequests;
using HR.LeaveManagement.Application.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand: IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
