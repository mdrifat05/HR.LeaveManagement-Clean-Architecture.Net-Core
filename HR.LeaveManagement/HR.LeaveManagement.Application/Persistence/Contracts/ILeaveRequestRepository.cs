using HR.LeaveManagemet.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest> 
    {
        Task ChangeApprovalStatus(LeaveRequest request, bool? ApprovalStatus);

    }
}
