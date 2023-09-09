using HR.LeaveManagement.Application.DTOs.LeaveRequests;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest: IRequest<List<LeaveRequestListDto>>
    {

    }
}
