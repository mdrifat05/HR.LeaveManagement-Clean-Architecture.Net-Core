﻿using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators
{
    public class UpdateLeaveAllocationDtoValidator: AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository) 
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveAllocationRepository));
        }
    }
}
