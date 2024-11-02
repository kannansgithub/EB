namespace EB.Application.Features.Accounts.Dtos;

public class ApplicationUserDto
{
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? ProfilePictureName { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsDeleted { get; set; }
    public IList<string> Roles { get; set; } = [];
    public IList<string> Claims { get; set; } = [];
};
