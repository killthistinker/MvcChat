using System.Collections.Generic;
using System.Threading.Tasks;
using homework_64.Models;
using homework_64.ViewModels;

namespace homework_64.Services.Abstractions
{
    public interface IMessageService
    {
        public IEnumerable<Message> GetNewMessages();
        public Task AddMessage(MessageViewModel model);
        public UserMessagesViewModel GetUserMessages(int userId);
        public IEnumerable<Message> GetMessages();
    }
}