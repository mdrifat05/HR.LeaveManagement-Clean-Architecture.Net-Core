using HR.LeaveManagment.Application.DTOs.LeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand: IRequest<int>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}
