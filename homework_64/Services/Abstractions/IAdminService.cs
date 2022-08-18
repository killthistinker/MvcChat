using homework_64.ViewModels;

namespace homework_64.Services.Abstractions
{
    public interface IAdminService
    {
        public void EditUser(ProfileEditViewModel model);
        public void BlockUser(int userId);
    }
}