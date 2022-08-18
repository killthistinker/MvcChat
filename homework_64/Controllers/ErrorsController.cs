using System.Collections.Generic;
using homework_64.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework_64.Controllers
{
    public class ErrorsController : Controller
    {
        private const string OppsMessage = "Oops... Ошибка";
        private readonly Dictionary<int, ErrorViewModel> _errorResolver;

        public ErrorsController()
        {
            _errorResolver = new Dictionary<int, ErrorViewModel>();
            _errorResolver.Add(404, new ErrorViewModel
            {
                StatusCode = 404,
                Message = "Ресурс не найден",
                Title = OppsMessage
            });
            _errorResolver.Add(403, new ErrorViewModel
            {
                StatusCode = 403,
                Message = "У вас нет прав доступа к данному ресурсу",
                Title = OppsMessage
            });
            _errorResolver.Add(500, new ErrorViewModel
            {
                StatusCode = 500,
                Message = "Сервер не смог обработать запрос",
                Title = OppsMessage
            });
            _errorResolver.Add(402, new ErrorViewModel
            {
                StatusCode = 402,
                Message = "Неправильный логин и (или) пароль",
                Title = OppsMessage
            });
            _errorResolver.Add(406, new ErrorViewModel
            {
                StatusCode = 406,
                Message = "Пользователь заблокирован, обратитесь к администратору",
                Title = OppsMessage
            });
            
            
        }

        [Route("Error/{statusCode}")]
        [ActionName("Error")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            if (_errorResolver.ContainsKey(statusCode))
            {
                return View(_errorResolver[statusCode]);
            }
            return View(_errorResolver[404]);
        }
    }
}