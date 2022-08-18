using System.ComponentModel.DataAnnotations;

namespace homework_64.ViewModels
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}