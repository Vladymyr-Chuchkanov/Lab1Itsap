using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWeb1.Controllers
{
    public class AccountController : Controller
    {
        private readonly DBLab1Context _context;
        public AccountController(DBLab1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            TempData["Comlexities"] = null;
            TempData["Types"] = null;
            TempData["Search"] = null;
            TempData["DateFrom"] =null;
            TempData["DateTo"] = null; 
            var data = new Items();
            data.account = new Account();
            data.WithoutAccount = false;
            string err = (string)TempData["ErrorLogIn"];
            if (err == "ErrorLogIn")
            {
                data.ErrorLogIn = "1";
                var login = (string)TempData["Login"];

                if (login != null)
                {
                    data.account.Email = login;
                }
            }
            else
            {
                data.ErrorLogIn = "0";
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Index(Items items)
        {
            if (items.WithoutAccount == true)
            {
                //TempData["AccId"] = 0;
                //TempData["Role"] = "гість";
                var app = new dAppItem{ AccId = 0, Role = "гість",idP=-1 };
                Dict.dApp = app;
                return RedirectToAction("Main","Main");
            }
            var acc = _context.Accounts.FirstOrDefault(a => a.Email == items.account.Email && a.Password == items.account.Password);
            
            if (acc != null)
            {
                //TempData["AccId"] = acc.AccountId;

                //TempData["Role"] = acc.RoleName;
                int idp = -1;
                var pers = _context.Partisipants.FirstOrDefault(a => a.IdAccount == acc.AccountId);
                if (pers != null)
                {
                    idp = pers.ParticipantId;
                }
                var app = new dAppItem { AccId = acc.AccountId, Role = acc.RoleName,idP=idp };
                Dict.dApp = app;
                if (acc.RoleName == null)
                {
                    //TempData["Role"] = "гість";
                    app.Role = "гість";
                }
                return RedirectToAction("Main", "Main") ;
            }
            else
            {
                TempData["ErrorLogIn"] = "ErrorLogIn";
                TempData["Login"] = items.account.Email;
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            string Err = (string)TempData["ErrorRegister"];
            if (Err == null)
            {
                Err = "0";
            }            
            var data = new Items();
            data.ErrorLogIn = Err;
            data.account=new Account();
            return View(data);
        }
        [HttpPost]
        public IActionResult Register(Items items)
        {
            if (items.account.Password != items.CheckPassword)
            {
                TempData["ErrorRegister"] = 1;
                return RedirectToAction("Register");
            }
            var acc = _context.Accounts.FirstOrDefault(a => a.Email == items.account.Email);
            if(acc != null)
            {
                TempData["ErrorRegister"] = 2;
                return RedirectToAction("Register");
            }
            else
            {
                acc = new Account();
                acc.Email = items.account.Email;
                acc.Password = items.account.Password;
                acc.RoleName = "гість";
                _context.Accounts.Add(acc);
                _context.SaveChanges();
                TempData["Login"] = items.account.Email;
                return RedirectToAction("Index");
            }
            
        }
        
    }
}
