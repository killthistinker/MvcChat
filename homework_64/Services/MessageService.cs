using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework_64.Helpers;
using homework_64.Models;
using homework_64.Services.Abstractions;
using homework_64.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace homework_64.Services
{
    public class MessageService : IMessageService
    {
        private readonly ChatContext _context;

        public MessageService(ChatContext context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetNewMessages()
        {
            var messages = _context.Messages.Include(u => u.User).OrderByDescending(m => m.DateOfCreate);
           
            return messages;
        }

        public async Task AddMessage(MessageViewModel model)
        {
            Message message = model.MapToMessage();
            if(message is null) return;

             await _context.Messages.AddAsync(message);
             await _context.SaveChangesAsync();
        }
        
        public UserMessagesViewModel GetUserMessages(int userId)
        {
            var messages = _context.Messages.Include(m => m.User).Where(u => u.UserId == userId);
            if (!messages.Any()) return null;

            User user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user is null) return null;

            UserMessagesViewModel model = new UserMessagesViewModel { Messages = messages, User = user };
            return model;
        }
        
        public  IEnumerable<Message> GetMessages()
        {
            var messages = _context.Messages.Include(u => u.User);
           
            return messages;
        }
    }
}