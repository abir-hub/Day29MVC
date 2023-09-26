using Microsoft.AspNetCore.Mvc;
using System;

namespace Day29MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult mySite(string name, string uname, string pass)
        {

            if (CRUD_ADO.CRUD.chkValidity( uname, pass))
            {
                if(CRUD_ADO.CRUD.chkAdmin(uname, pass))
                {
                    return RedirectToAction("adminPage");
                }
                return RedirectToAction("Success");
            }
            return RedirectToAction("Failure");


        }
        public IActionResult adminPage()
        {
            return View();
        }
        public IActionResult updatePage()
        {
            return View();
        }

        public IActionResult Update(string name, string oldPass, string newPass, string confPass)
        {
            if (CRUD_ADO.CRUD.updateValidity(name, oldPass, newPass, confPass))
            {
                return RedirectToAction("Success");
            }
            return RedirectToAction("Failure");
        }



        public IActionResult DeletePage()
        {
            return View();
        }
        public IActionResult Delete(string name, string uname,string pass)
        {
            if (CRUD_ADO.CRUD.deleteValidity(name,uname, pass))
            {
                return RedirectToAction("Success");
            }
            return RedirectToAction("Failure");
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Failure()
        {
            return View();
        }
    }
}
