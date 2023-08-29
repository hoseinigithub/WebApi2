using Application.Interfaces.Contexts;
using Common;

namespace Application.Services.Users.Commands.DeleteUser
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IDatabaseContext _context;

        public DeleteUserService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return new ResultDto
                {
                    IsSucces = false,
                    StatusCode = 404,
                    Message = "User Not Found!"
                };
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucces = true,
                Message = "Delete User is Successfully",
                StatusCode = 200
            };
        }
    }
}