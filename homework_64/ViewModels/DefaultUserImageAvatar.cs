using homework_64.Services.Abstractions;

namespace homework_64.ViewModels
{
    public class DefaultUserImageAvatar : IDefaultUserImageAvatar
    {
        private readonly string _path;

        public DefaultUserImageAvatar(string path)
        {
            _path = path;
        }

        public string GetPathToDefaultImage() => _path;
    }
}