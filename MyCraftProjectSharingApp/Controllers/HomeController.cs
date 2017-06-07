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
    public class HomeController : Controller
    {
        // GET: Home
        static HousesLogic _housesBusinessLogic = new HousesLogic();
        static MapperHouses _housesMapper = new MapperHouses();
        public ActionResult Index()
        {
            BusinessLogicHouses blTopHouse = _housesBusinessLogic.TopHousePoints();
            Houses topHouse = _housesMapper.Maphouse(blTopHouse);

            ViewModel houseVM = new ViewModel();
            houseVM.SingleHouse = topHouse;

            return View(houseVM);
        } //main home page
    }
}