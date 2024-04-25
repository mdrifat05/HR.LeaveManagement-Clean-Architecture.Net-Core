using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveTypes.Validators;

public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
{
    public CreateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());
    }
}
