using System.Linq;
using homework_64.Models;
using homework_64.Services.Abstractions;
using homework_64.ViewModels;

namespace homework_64.Services
{
    public class AdminService : IAdminService
    {
        private readonly ChatContext _context;

        public AdminService(ChatContext context)
        {
            _context = context;
        }

        public void EditUser(ProfileEditViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == model.UserId);
            if (user is null) return;
            if (model.Email != null)
            {
                user.Email = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if (model.UserName != null)
            {
                user.UserName = model.UserName;
                user.NormalizedUserName = model.UserName.ToUpper();
            }
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void BlockUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if(user is null) return;

            if (user.Block)
            {
                user.Block = false;
            }
            else
            {
                user.Block = true;
            }

            _context.Update(user);
            _context.SaveChanges();
        }
    }
}