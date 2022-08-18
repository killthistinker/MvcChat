using System.Collections.Generic;
using homework_64.Models;

namespace homework_64.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Message> Messages { get; set; }
        public MessageViewModel Model { get; set; }
    }
}