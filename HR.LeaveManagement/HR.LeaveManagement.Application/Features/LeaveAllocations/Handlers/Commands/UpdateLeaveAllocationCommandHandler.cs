using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateleaveAllocationDto);
            if (validationResult.IsValid == false) 
            {
                throw new ValidationException(validationResult);
            }
            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateleaveAllocationDto.Id);
            if (leaveAllocation is null)
            {
                throw new NotFoundException(nameof(leaveAllocation), request.UpdateleaveAllocationDto.Id);
            }
                
            _mapper.Map(request.UpdateleaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
