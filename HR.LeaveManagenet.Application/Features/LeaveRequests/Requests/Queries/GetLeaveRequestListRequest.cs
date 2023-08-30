using HR.LeaveManagment.Application.DTOs.LeaveRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest: IRequest<List<LeaveRequestListDto>>
    {

    }
}
