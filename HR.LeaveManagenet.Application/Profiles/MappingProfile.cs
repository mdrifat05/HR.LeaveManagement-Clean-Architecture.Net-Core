using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveAllocations;
using HR.LeaveManagment.Application.DTOs.LeaveRequests;
using HR.LeaveManagment.Application.DTOs.LeaveTypes;
using HR.LeaveManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Profiles
{
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
}
