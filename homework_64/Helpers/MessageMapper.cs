using System;
using homework_64.Models;
using homework_64.ViewModels;

namespace homework_64.Helpers
{
    public static class MessageMapper
    {
        public static Message MapToMessage(this MessageViewModel self)
        {
            Message message = new Message
            {
                Description = self.Description,
                UserId = self.UserId,
                DateOfCreate = DateTime.Now
            };
            return message;
        }
    }
}