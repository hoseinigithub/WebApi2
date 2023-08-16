namespace Domain.Entities.Users;

public class User
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PostalCode { get; set; }
    public string BuildingNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<UserInRole> UserInRoles { get; set; }
}