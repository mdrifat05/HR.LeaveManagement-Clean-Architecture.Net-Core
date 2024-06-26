﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(
        IUnitOfWork unitOfWork,
         IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _unitOfWork.LeaveRequestRepository.Get(request.Id);

        if (leaveRequest is null)
            throw new NotFoundException(nameof(leaveRequest), request.Id);

        if (request.UpdateLeaveRequestDto != null)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            _mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);

            await _unitOfWork.LeaveRequestRepository.Update(leaveRequest);
            await _unitOfWork.Save();
        }
        else if (request.ChangeLeaveRequestApprovalDto != null)
        {
            await _unitOfWork.LeaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            if (request.ChangeLeaveRequestApprovalDto.Approved)
            {
                var allocation = await _unitOfWork.LeaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

                allocation.NumberOfDays -= daysRequested;

                await _unitOfWork.LeaveAllocationRepository.Update(allocation);
            }

            await _unitOfWork.Save();
        }

        return Unit.Value;
    }
}
