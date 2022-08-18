using System.Collections.Generic;
using System.Threading.Tasks;
using homework_64.Models;
using homework_64.ViewModels;

namespace homework_64.Services.Abstractions
{
    public interface IProfileService
    {
        public Task<User> GetUser(string name);
        public void Edit(ProfileEditViewModel model);
        public IEnumerable<User> GetUsers();
    }
}