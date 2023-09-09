using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveTypes.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is Required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.DefaultDays)
               .NotEmpty().WithMessage("{PropertyName} is Required.")
               .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
               .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");
        }
    }
}
