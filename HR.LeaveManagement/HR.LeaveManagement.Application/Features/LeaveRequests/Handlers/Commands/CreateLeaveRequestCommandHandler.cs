using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler: IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Leave Request Failed!";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
                leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
                response.Success = true;
                response.Message = "Request Created Successfully";
                response.Id = leaveRequest.Id;
            }
            return response;   
        }
    }
}
