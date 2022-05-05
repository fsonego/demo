using mvp.application.Common.Mappings;
using mvp.domain.Entities;

namespace mvp.application.Users.Queries.GetAllUsersByActive;

public class UserDto
{
    public Guid UserId { get; set; }
    public string? UserName { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool? Active { get; set; }
}
