using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}
