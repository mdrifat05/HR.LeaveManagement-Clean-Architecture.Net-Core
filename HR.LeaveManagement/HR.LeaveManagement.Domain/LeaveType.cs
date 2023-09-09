using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain
{
    public class LeaveType: BaseDomainEntity
    {
        public string Name { get; set; }
        public string DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
