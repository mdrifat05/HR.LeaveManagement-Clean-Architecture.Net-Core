using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;


namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;

    public CreateLeaveAllocationCommandHandler(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userService = userService; 
    }
    public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);
        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Allocations Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var leaveType = await _unitOfWork.LeaveTypeRepository.Get(request.CreateLeaveAllocationDto.LeaveTypeId);
            var employees = await _userService.GetEmployees();
            var period = DateTime.Now.Year;
            var allocations = new List<LeaveAllocation>();
            foreach (var emp in employees)
            {
                if (await _unitOfWork.LeaveAllocationRepository.AllocationExists(emp.Id, leaveType.Id, period))
                    continue;
                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = emp.Id,
                    LeaveTypeId = leaveType.Id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = period
                });
            }

            await _unitOfWork.LeaveAllocationRepository.AddAllocations(allocations);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Allocations Successful";
        }
        return response;
    }
}
