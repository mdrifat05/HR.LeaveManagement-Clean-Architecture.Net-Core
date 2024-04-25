using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;

public class GetLeaveAllocationListRequest: IRequest<List<LeaveAllocationDto>>
{
    public bool IsLoggedInUser { get; set; }
}
