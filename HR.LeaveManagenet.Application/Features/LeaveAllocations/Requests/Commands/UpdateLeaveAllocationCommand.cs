using HR.LeaveManagment.Application.DTOs.LeaveAllocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand: IRequest<Unit>
    {
        public LeaveAllocationDto leaveAllocationDto { get; set; }
    }
}
