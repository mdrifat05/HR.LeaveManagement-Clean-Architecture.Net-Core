﻿namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations;

public class CreateLeaveAllocationDto: ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
