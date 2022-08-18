using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework_64.Models;
using homework_64.Services.Abstractions;
using homework_64.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace homework_64.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly ChatContext _chatContext;

        public ProfileService(UserManager<User> userManager, ChatContext chatContext)
        {
            _userManager = userManager;
            _chatContext = chatContext;
        }

        public async Task<User> GetUser(string name)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == name);
            if (user is null) return null;
            return user;
        }

        public void Edit(ProfileEditViewModel model)
        {
            var user = _chatContext.Users.FirstOrDefault(u => u.Id == model.UserId);
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
            _chatContext.Users.Update(user);
            _chatContext.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _chatContext.Users.AsEnumerable();
            return users;
        }
    }
}