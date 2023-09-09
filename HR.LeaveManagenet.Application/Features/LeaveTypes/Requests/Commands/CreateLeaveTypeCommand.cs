﻿using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand: IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}
