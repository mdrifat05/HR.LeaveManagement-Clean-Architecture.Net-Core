using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveRequests;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagment.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Handlers.Queries
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
