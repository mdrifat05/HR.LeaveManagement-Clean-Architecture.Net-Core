using HR.LeaveManagement.Application.DTOs.Common;

namespace HR.LeaveManagement.Application.DTOs.LeaveTypes;

public class LeaveTypeDto: BaseDto, ILeaveTypeDto
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
