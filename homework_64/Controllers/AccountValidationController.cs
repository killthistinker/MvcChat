using System;
using System.Linq;
using homework_64.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework_64.Controllers
{
    public class AccountValidationController : Controller
    {
        private readonly ChatContext _context;

        public AccountValidationController(ChatContext context)
        {
            _context = context;
        }

        public bool CheckAccountEmail(string email)
        {
            bool validation = !_context.Users.AsEnumerable().Any(p => p.Email.Equals(email));
            return validation;
        }

        public bool CheckAccountName(string userName)
        {
            bool validation = !_context.Users.AsEnumerable().Any(p => p.UserName.Equals(userName));
            return validation;
        }

        public bool CheckAccountAge(DateTime dateOfBirth)
        {
            int year = DateTime.Now.Year - dateOfBirth.Year;
            
            if (DateTime.Now.Month < dateOfBirth.Month || (DateTime.Now.Month == dateOfBirth.Month && DateTime.Now.Day < dateOfBirth.Day))
            {
                year--;
            }
            
            if (year < 18) return false;
            
            return true;
        }
    }
}