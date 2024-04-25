using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using HR.LeaveManagement.Application.DTOs.LeaveRequests;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
          
    }
}
