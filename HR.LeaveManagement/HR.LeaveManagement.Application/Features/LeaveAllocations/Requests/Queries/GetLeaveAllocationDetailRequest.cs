using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest: IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
