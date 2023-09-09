using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveTypes.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        ILeaveTypeRepository _leaveTypeRepository;
        IMapper _mapper;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveTypeDto);
            if(validationResult.IsValid == false) 
            {
                throw new ValidationException(validationResult);
            }
            var leaveType = await _leaveTypeRepository.Get(request.UpdateLeaveTypeDto.Id);
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(leaveType), request.UpdateLeaveTypeDto.Id);
            }
            _mapper.Map(request.UpdateLeaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);
            return Unit.Value;
        }
    }
}
