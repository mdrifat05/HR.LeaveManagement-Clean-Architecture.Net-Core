using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators;

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        RuleFor(p => p.StartDate)
        .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

        RuleFor(p => p.EndDate)
            .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");
        RuleFor(p => p.LeaveTypeId)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                return !leaveTypeExists;
            })
        .WithMessage("{PropertyName} does not exists.");
    }
}
