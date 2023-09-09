﻿using HR.LeaveManagemet.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest> 
    {
        Task ChangeApprovalStatus(LeaveRequest request, bool? ApprovalStatus);

    }
}
