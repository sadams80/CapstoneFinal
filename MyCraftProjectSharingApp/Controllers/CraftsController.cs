using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCraftProjectSharingApp.Models;
using MyCraftProjectSharingApp.Mappers;
using BusinessLogicLayer;

namespace MyCraftProjectSharingApp.Controllers
{
    public class CraftsController : Controller
    {
        // GET: Crafts
        static CraftsLogic _craftBusinessLogic = new CraftsLogic();
        static UsersLogic _userBusinessLogic = new UsersLogic();
        static MapperCrafts _craftMapper = new MapperCrafts();
        static MapperUsers _userMapper = new MapperUsers();
        static HousesController _houseController = new HousesController();
        public ActionResult Index()
        {
            return View("Index", "Home", new { are = "" });
        } //returns to home controller homepage
        [HttpGet]
        public ActionResult CreateCraft()
        {
            ViewModel craftViewModel = new ViewModel();
            if (Session["RoleID"] != null)
            {
                if (Session["UserId"] != null && (int)Session["RoleID"] != 1)
                {
                    craftViewModel.SingleCraft.User_ID = (int)Session["UserId"];
                    return View(craftViewModel);
                }
                else
                {
                    return RedirectToAction("PageError", "Error", new { area = "" });
                }
            }
            else
            {
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        } //create craft for power user and admin
        [HttpPost]
        public ActionResult CreateCraft(ViewModel craftToAdd)
        {
            if (Session["RoleID"] != null)
            {
                if ((int)Session["RoleID"] != 1)
                {
                    if (ModelState.IsValid)
                    {
                        Crafts craft = new Crafts();
                        craft = _craftMapper.MapCraft(_craftBusinessLogic.GetCraftByCraftName(craftToAdd.SingleCraft.CraftName));
                        if (craft.CraftName == null)
                        {
                            _craftBusinessLogic.AddCraft(_craftMapper.MapCraft(craftToAdd.SingleCraft));
                            _houseController.AddPoints(50, (int)Session["House_ID"]);
                            if ((int)Session["House_ID"] == 1)
                            {
                                TempData["CraftSuccess"] = "50 points to GRYFFINDOR!";
                            }
                            else if ((int)Session["House_ID"] == 2)
                            {
                                TempData["CraftSuccess"] = "50 points to SLYTHERIN!";
                            }
                            else if ((int)Session["House_ID"] == 3)
                            {
                                TempData["CraftSuccess"] = "50 points to RAVENCLAW!";
                            }
                            else if ((int)Session["House_ID"] == 4)
                            {
                                TempData["CraftSuccess"] = "50 points to HUFFLEPUFF!";
                            }
                            return RedirectToAction("ViewAllCrafts", "Crafts", new { area = "" });
                        }
                        else
                        {
                            TempData["CraftError"] = "Craft name already exists";
                            return View();
                        }
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("PageError", "Errors", new { area = "" });
                }
            }
            else
            {
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        } //create craft for power user and admin
        public ActionResult ViewAllCrafts()
        {
            if (Session["RoleID"] != null)
            {
                ViewModel crafts = new ViewModel();
                ViewModel users = new ViewModel();
                crafts.Crafts = _craftMapper.MapCrafts(_craftBusinessLogic.GetCrafts());
                foreach (Crafts craft in crafts.Crafts)
                {
                    users.SingleUser = _userMapper.MapUser(_userBusinessLogic.GetUserByUserId(craft.User_ID));
                    if (craft.User_ID == users.SingleUser.User_ID)
                    {
                        craft.Username = users.SingleUser.Username;
                    }
                }
                return View(crafts);
            }
            else
            {
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        } //View all crafts for individual and admin
        [HttpGet]
        public ActionResult UpdateCraft(int craftToUpdate)
        {
            if (Session["RoleID"] != null)
            {
                Crafts craft = new Crafts();
                craft = _craftMapper.MapCraft(_craftBusinessLogic.GetCraftByCraftId(craftToUpdate));
                if ((int)Session["UserId"] == craft.User_ID && (int)Session["RoleID"] != 1 || (int)Session["RoleID"] == 3)
                {
                    ViewModel craftViewModel = new ViewModel();
                    craftViewModel.SingleCraft = _craftMapper.MapCraft(_craftBusinessLogic.GetCraftByCraftId(craftToUpdate));
                    craftViewModel.SingleCraft.User_ID = craft.User_ID;
                    return View(craftViewModel);
                }
                else
                {
                    return RedirectToAction("PageError", "Error", new { area = "" });
                }
            }
            else
            {
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        }  //update craft for power user and admin
        [HttpPost]
        public ActionResult UpdateCraft(ViewModel craftToUpdate)
        {
            if (Session["RoleID"] != null)
            {
                if (ModelState.IsValid)
                {
                    if ((int)Session["UserId"] == craftToUpdate.SingleCraft.User_ID || (int)Session["RoleID"] == 3)
                    {
                        Crafts craft = new Crafts();
                        craft = _craftMapper.MapCraft(_craftBusinessLogic.GetCraftByCraftName(craftToUpdate.SingleCraft.CraftName));
                        if (craft.CraftName == null || craft.CraftName == craftToUpdate.SingleCraft.CraftName)
                        {
                            if (craft.User_ID == (int)Session["UserId"] || (int)Session["RoleId"] == 3)
                            {
                                _craftBusinessLogic.UpdateCraft(craftToUpdate.SingleCraft.Craft_ID, _craftMapper.MapCraft(craftToUpdate.SingleCraft));
                                TempData["CraftSuccess"] = "Craft successfully updated.";
                                return RedirectToAction("ViewAllCrafts", "Crafts", new { area = "" });
                            }
                            else
                            {
                                return RedirectToAction("PageError", "Error", new { area = "" });
                            }
                        }
                        else
                        {
                            TempData["CraftError"] = "Craft name already exists";
                            return View();
                        }
                    }
                    else
                    {
                        return RedirectToAction("PageError", "Error", new { area = "" });
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        }  //update craft for power user and admin
        public ActionResult DeleteCraft(int craftToDelete)
        {
            if (Session["RoleID"] != null)
            {
                if ((int)Session["RoleID"] != 1)
                {
                    Crafts craft = new Crafts();
                    craft = _craftMapper.MapCraft(_craftBusinessLogic.GetCraftByCraftId(craftToDelete));
                    if ((int)Session["UserId"] == craft.User_ID && (int)Session["RoleID"] != 3)
                    {
                        _craftBusinessLogic.DeleteCraft(craftToDelete);
                        _houseController.AddPoints(-50, (int)Session["House_ID"]);
                        TempData["DeleteSuccess"] = "Craft successfully deleted.";
                        return RedirectToAction("ViewAllCrafts", "Crafts", new { area = "" });
                    }
                    else
                    {
                        ViewModel user = new ViewModel();
                        user.SingleUser = _userMapper.MapUser(_userBusinessLogic.GetUserByUserId(craft.User_ID));
                        if (craft.User_ID == user.SingleUser.User_ID)
                        {
                            _houseController.AddPoints(-50, user.SingleUser.House_ID);
                        }
                        _craftBusinessLogic.DeleteCraft(craftToDelete);
                        TempData["DeleteSuccess"] = "Craft successfully deleted.";
                        return RedirectToAction("ViewAllCrafts", "Crafts", new { area = "" });
                    }
                }
                else
                {
                    return RedirectToAction("PageError", "Error", new { area = "" });
                }
            }
            else
            {
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        } //delete craft for power user and admin
    }
}