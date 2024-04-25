using HR.LeaveManagement.Application.DTOs.Common;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequests;

public class ChangeLeaveRequestApprovalDto : BaseDto
{
    public bool Approved { get; set; }
}
