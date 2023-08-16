namespace Domain.Entities.Users;

public class UserInRole
{
    public int Id { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }
}