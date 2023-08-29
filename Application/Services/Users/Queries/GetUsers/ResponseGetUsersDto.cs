namespace Application.Services.Users.Queries.GetUsers
{
    public class ResponseGetUsersDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<RoleDto> Roles { get; set; }
    }

    public class RoleDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}