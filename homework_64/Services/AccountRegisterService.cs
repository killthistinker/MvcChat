using System;
using System.IO;
using System.Threading.Tasks;
using homework_64.Services.Abstractions;
using homework_64.ViewModels;
using Microsoft.Extensions.Hosting;

namespace homework_64.Services
{
    public class AccountRegisterService : IAccountRegisterService
    {
        private readonly IDefaultUserImageAvatar _imagePathProvider;
        private readonly UploadService _uploadService;
        private readonly IHostEnvironment _environment;

        public AccountRegisterService(IDefaultUserImageAvatar imagePathProvider, UploadService uploadService, IHostEnvironment environment)
        {
            _imagePathProvider = imagePathProvider;
            _uploadService = uploadService;
            _environment = environment;
        }

        
        public async Task CreateAsync(RegisterViewModel entity, string userName)
        {
            string imagePath;
            if (entity.File is null)
                imagePath = _imagePathProvider.GetPathToDefaultImage();
            
            else
            {
                string dirPath = Path.Combine(_environment.ContentRootPath, $"wwwroot\\images\\userImages\\{entity.Email}");
                string guid = Guid.NewGuid().ToString();
                string fileName = $"{guid + entity.File.FileName}";
                await _uploadService.UploadAsync(dirPath, fileName, entity.File);
                imagePath = $"images\\userImages\\{entity!.Email}\\{fileName}";
            }

            entity.ImagePath = imagePath;
        }
    }
}