using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCraftProjectSharingApp.Models
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("Index", "Home", new { area = "" });
        } //return to main homepage
        public ActionResult PageError()
        {
            return View();
        }  //displays error when users don't have permission to go to a page
    }
}