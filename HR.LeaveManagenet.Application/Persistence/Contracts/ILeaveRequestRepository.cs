using HR.LeaveManagenet.Application.Persistence.Contracts;
using HR.LeaveManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest> 
    {
        Task ChangeApprovalStatus(LeaveRequest request, bool? ApprovalStatus);
    }
}
