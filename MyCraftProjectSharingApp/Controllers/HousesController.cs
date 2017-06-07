using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCraftProjectSharingApp.Models;
using MyCraftProjectSharingApp.Mappers;
using BusinessLogicLayer;
using BusinessLogicLayer.BusinessLogicObjects;

namespace MyCraftProjectSharingApp.Controllers
{
    public class HousesController : Controller
    {
        // GET: Houses
        static HousesLogic _housesBusinessLogic = new HousesLogic();
        static MapperHouses _housesMapper = new MapperHouses();
        public ActionResult Index()
        {
            return View("Index", "Home", new { are = "" });
        }  //return to main homepage
        public ActionResult ViewHouses()
        {
            if (Session["RoleID"] != null)
            {
                ViewModel houses = new ViewModel();
                houses.Houses = _housesMapper.MapHouses(_housesBusinessLogic.GetHouses());
                return View(houses);
            }
            else
            {
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        }  //view houses for all users
        [HttpPost]
        public void AddPoints(long points, int houseId)
        {
            _housesBusinessLogic.UpdateHousePoints(points, houseId);
        }  //add points method
    }
}