using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.Application.Models.Identity;

public class RegistrationRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [MinLength(6)]
    public string UserName { get; set; }

    [MinLength(6)]
    public string Password { get; set; }
}
