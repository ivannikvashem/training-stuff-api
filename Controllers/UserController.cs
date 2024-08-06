using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using training_stuff_api.Models;

namespace training_stuff_api.Controllers
{
    public class UserController : Controller
    {
        private readonly StuffTrainingPlatformContext _context;

        public UserController(StuffTrainingPlatformContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(string userId)
        {
            return await _context.User.FindAsync(userId);
        }

        public async Task UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
