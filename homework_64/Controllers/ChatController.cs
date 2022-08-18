using System.Linq;
using System.Threading.Tasks;
using homework_64.Models;
using homework_64.Services.Abstractions;
using homework_64.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace homework_64.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<User> _userManager;

        public ChatController(IMessageService messageService, UserManager<User> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var messages = _messageService.GetNewMessages();
            IndexViewModel model = new IndexViewModel { Messages = messages.Take(30).Reverse()};
            int.TryParse(_userManager.GetUserId(User), out int userId);
            ViewBag.AuthorizedId = userId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage([FromBody]MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                int.TryParse(_userManager.GetUserId(User), out int userId);
                model.UserId = userId;
               await _messageService.AddMessage(model);
                var messages = _messageService.GetMessages();
                ViewBag.AuthorizedId = userId;
                return PartialView("PatrialViews/MessagePatrialView", messages);
            }

            return RedirectToAction("Error", "Errors", new { statuscode = 404 });
        }

        [HttpGet]
        public IActionResult GetUserMessageCount(int userId)
        {
            var messages = _messageService.GetUserMessages(userId);
            if (messages == null)
            {
                return RedirectToAction("Error", "Errors", new { statusCode = 404 });
            }

            return View(messages);
        }

        [HttpGet]
        public  IActionResult GetMessages()
        {
            int.TryParse(_userManager.GetUserId(User), out int userId);
            ViewBag.AuthorizedId = userId;
            var messages = _messageService.GetMessages();
            return PartialView("PatrialViews/MessagePatrialView", messages);
        }
    }
}