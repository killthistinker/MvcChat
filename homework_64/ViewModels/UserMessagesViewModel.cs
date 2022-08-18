using System.Collections.Generic;
using homework_64.Models;

namespace homework_64.ViewModels
{
    public class UserMessagesViewModel
    {
        public User User { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}