﻿using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators
{
    public class CreateLeaveRequestDtoValidator: AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
           Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));
        }
    }
}
