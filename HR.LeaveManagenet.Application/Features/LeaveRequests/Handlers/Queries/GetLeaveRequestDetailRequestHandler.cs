using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequests;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
    {
            private readonly ILeaveRequestRepository _leaveRequestRepository;
            private readonly IMapper _mapper;

            public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
            {
                _leaveRequestRepository = leaveRequestRepository;
                _mapper = mapper;
            }
            public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
            {
                var leaveAllocation = await _leaveRequestRepository.Get(request.Id);
                return _mapper.Map<LeaveRequestDto>(leaveAllocation);
            }
    }
}
