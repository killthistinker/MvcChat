using homework_64.Models;
using homework_64.ViewModels;

namespace homework_64.Helpers
{
    public static class UserRegistrationMapper
    {
        public static User MapToUser(this RegisterViewModel self)
        {
            User user = new User
            {
                Email = self.Email,
                UserName = self.UserName,
                Avatar = self.ImagePath,
                DateOfBirth = self.DateOfBirth,
                Block = false
            };
            return user;
        }
    }
}