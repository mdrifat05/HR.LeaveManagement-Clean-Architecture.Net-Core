﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveTypes.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.UpdateLeaveTypeDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var leaveType = await _unitOfWork.LeaveTypeRepository.Get(request.UpdateLeaveTypeDto.Id);

        if (leaveType is null)
            throw new NotFoundException(nameof(leaveType), request.UpdateLeaveTypeDto.Id);

        _mapper.Map(request.UpdateLeaveTypeDto, leaveType);

        await _unitOfWork.LeaveTypeRepository.Update(leaveType);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}
