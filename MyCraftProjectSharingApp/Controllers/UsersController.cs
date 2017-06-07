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
    public class UsersController : Controller
    {
        // GET: Users
        static UsersLogic _userBusinessLogic = new UsersLogic();
        static HousesLogic _housesBusinessLogic = new HousesLogic();
        static RolesLogic _rolesBusinessLogic = new RolesLogic();
        static PaswordHashLogic _hashBusinessLogic = new PaswordHashLogic();
        static MapperUsers _userMapper = new MapperUsers();
        static MapperHouses _housesMapper = new MapperHouses();
        static MapperRoles _rolesMapper = new MapperRoles();
        static HousesController _houseController = new HousesController();
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        } //return to home page
        [HttpGet]
        public ActionResult Login(string username, string password)
        {
            return View();
        } //add user info to session for all users
        [HttpPost]
        public ActionResult Login(ViewModel userToLogin)
        {
            Users user = new Users();
            user = _userMapper.MapUser(_userBusinessLogic.GetUserByUsername(userToLogin.SingleUser.Username));
            if (ModelState.IsValid)
            {
                if (user.Username != null)
                {
                    if (user.Password != null)
                    {
                        string userPassword = _hashBusinessLogic.HashPassword(userToLogin.SingleUser.Password);   //giving different hashed values even without salt
                        if (userPassword == user.Password)
                        {
                            Session["UserId"] = user.User_ID;
                            Session["Username"] = user.Username;
                            Session["RoleID"] = user.Role_ID;
                            Session["House_ID"] = user.House_ID;
                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                        TempData["LoginError"] = "Username or password is incorrect. Please check and try again.";
                        return View();
                    }
                    else
                    {
                        TempData["LoginError"] = "Username or password is incorrect. Please check and try again.";
                        return View();
                    }
                }
                TempData["LoginError"] = "Username does not exist. Please check and try again.";
                return View();
            }
            else
            {
                return View();
            }
        } //add user info to session for all users
        public ActionResult Logout()
        {
            if (Session["RoleID"] != null)
            {
                Session.Clear();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        } //clear session for all users
        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewModel housesViewModel = new ViewModel();
            housesViewModel.Houses = _housesMapper.MapHouses(_housesBusinessLogic.GetHouses());
            return View(housesViewModel);
        } //create reg user
        [HttpPost]
        public ActionResult CreateUser(ViewModel userToAdd)
        {
            if (!ModelState.IsValid)
            {
                TempData["CreateError"] = "All fields are required.";
                userToAdd.Houses = _housesMapper.MapHouses(_housesBusinessLogic.GetHouses());
                return View(userToAdd);
            }
            else
            {
                if (userToAdd.SingleUser.House_ID != null && userToAdd.SingleUser.FirstName != null && userToAdd.SingleUser.LastName != null && userToAdd.SingleUser.Email != null && userToAdd.SingleUser.Age != null)
                {
                    Users user = new Users();
                    user = _userMapper.MapUser(_userBusinessLogic.GetUserByUsername(userToAdd.SingleUser.Username));
                    if (user.Username == null)
                    {
                        _userBusinessLogic.AddUser(_userMapper.MapUser(userToAdd.SingleUser));
                        user = _userMapper.MapUser(_userBusinessLogic.GetUserByUsername(userToAdd.SingleUser.Username));
                        if (user.Username == userToAdd.SingleUser.Username)
                        {
                            _houseController.AddPoints(5, userToAdd.SingleUser.House_ID);
                            if (userToAdd.SingleUser.House_ID == 1)
                            {
                                TempData["UserCreateSuccess"] = "5 points to GYFFINDOR!";
                            }
                            else if (userToAdd.SingleUser.House_ID == 2)
                            {
                                TempData["UserCreateSuccess"] = "5 points to SLYTHERIN!";
                            }
                            else if (userToAdd.SingleUser.House_ID == 3)
                            {
                                TempData["UserCreateSuccess"] = "5 points to RAVENCLAW!";
                            }
                            else if (userToAdd.SingleUser.House_ID == 4)
                            {
                                TempData["UserCreateSuccess"] = "5 points to HUFFLEPUFF!";
                            }
                            return RedirectToAction("Login", "Users", new { area = "" });
                        }
                        else
                        {
                            TempData["UsernameError"] = "There was an error creating your account. Please try again.";
                            userToAdd.Houses = _housesMapper.MapHouses(_housesBusinessLogic.GetHouses());
                            return View(userToAdd);
                        }
                    }
                    else
                    {
                        TempData["UsernameError"] = "Username is already in use. Please choose another.";
                        userToAdd.Houses = _housesMapper.MapHouses(_housesBusinessLogic.GetHouses());
                        return View(userToAdd);
                    }
                }
                else
                {
                    TempData["CreateError"] = "All fields are required.";
                    userToAdd.Houses = _housesMapper.MapHouses(_housesBusinessLogic.GetHouses());
                    return View(userToAdd);
                }
            }
        } //create reg user
        public ActionResult ViewUserByUserId()
        {
            Users user = new Users();
            ViewModel userViewModel = new ViewModel();
            if (Session["RoleID"] != null && Session["UserId"] != null)
            {
                int userToGet = (int)Session["UserId"];
                user = _userMapper.MapUser(_userBusinessLogic.GetUserByUserId(userToGet));
                if ((int)Session["UserId"] == user.User_ID)
                {
                    userViewModel.SingleUser = _userMapper.MapUser(_userBusinessLogic.GetUserByUserId(userToGet));
                    TempData["UserRole"] = userViewModel.SingleUser.Role_ID;
                    return View(userViewModel);
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
        } //View for individual users
        public ActionResult ViewAllUsers()
        {
            if (Session["RoleID"] != null)
            {
                if ((int)Session["RoleID"] == 3)
                {
                    ViewModel users = new ViewModel();
                    users.Users = _userMapper.MapUsers(_userBusinessLogic.GetUsers());
                    
                    return View(users);
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
        } //View for admin user
        [HttpGet]
        public ActionResult UpdateUser(int userId)
        {
            if (Session["RoleID"] != null)
            {
                if (userId == (int)Session["UserId"] || (int)Session["RoleID"] == 3)
                {
                    ViewModel userToUpdate = new ViewModel();
                    userToUpdate.SingleUser = _userMapper.MapUser(_userBusinessLogic.GetUserByUserId(userId));
                    userToUpdate.SingleUser.Password = "";
                    userToUpdate.Roles = _rolesMapper.MapRoles(_rolesBusinessLogic.GetRoles());
                    return View(userToUpdate);
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
        } //Update for individual users and admin
        [HttpPost]
        public ActionResult UpdateUser(ViewModel userToUpdate)
        {
            if (Session["RoleID"] != null && Session["UserId"] != null)
            {
                if (userToUpdate.SingleUser.User_ID == (int)Session["UserId"] || (int)Session["RoleID"] == 3)
                {
                    if (ModelState.IsValid)
                    {
                        if (userToUpdate.SingleUser.FirstName != null && userToUpdate.SingleUser.LastName != null && userToUpdate.SingleUser.Email != null && userToUpdate.SingleUser.Age != null)
                        {
                            Users user = new Users();
                            user = _userMapper.MapUser(_userBusinessLogic.GetUserByUsername(userToUpdate.SingleUser.Username));
                            if (user.Username == null || user.Username == userToUpdate.SingleUser.Username)
                            {
                                if ((int)Session["RoleID"] == 3)
                                {
                                    if (userToUpdate.SingleUser.Role_ID != null)
                                    {
                                        user.Role_ID = userToUpdate.SingleUser.Role_ID;
                                        _userBusinessLogic.UpdateUser(userToUpdate.SingleUser.User_ID, _userMapper.MapUser(userToUpdate.SingleUser));
                                        if (userToUpdate.SingleUser.User_ID == (int)Session["UserId"])
                                        {
                                            return RedirectToAction("ViewUserByUserId", "Users", new { area = "" });
                                        }
                                        else
                                        {
                                            return RedirectToAction("ViewAllUsers", "Users", new { area = "" });
                                        }
                                    }

                                    else
                                    {
                                        TempData["UpdateError"] = "All fields are required.";
                                        return View(userToUpdate);
                                    }
                                }
                                else
                                {
                                    userToUpdate.SingleUser.Role_ID = (int)Session["RoleID"];
                                    _userBusinessLogic.UpdateUser(userToUpdate.SingleUser.User_ID, _userMapper.MapUser(userToUpdate.SingleUser));
                                    return RedirectToAction("ViewUserByUserId", "Users", new { area = "" });
                                }
                            }
                            else
                            {
                                TempData["UsernameError"] = "Username is already in use. Please choose another.";
                                userToUpdate.Roles = _rolesMapper.MapRoles(_rolesBusinessLogic.GetRoles());
                                return View(userToUpdate);
                            }
                        }
                        else
                        {
                            TempData["UpdateError"] = "All fields are required.";
                            userToUpdate.Roles = _rolesMapper.MapRoles(_rolesBusinessLogic.GetRoles());
                            return View(userToUpdate);
                        }
                    }
                    else
                    {
                        TempData["UpdateError"] = "All fields are required.";
                        userToUpdate.Roles = _rolesMapper.MapRoles(_rolesBusinessLogic.GetRoles());
                        return View(userToUpdate);
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
        } //Update for individual users and admin
        [HttpGet]
        public ActionResult DeleteUser(int userId)
        {
            if (Session["RoleId"] != null)
            {
                Users userToDelete = new Users();
                userToDelete = _userMapper.MapUser(_userBusinessLogic.GetUserByUserId(userId));
                if ((int)Session["RoleID"] == 3)
                {
                    if (userToDelete.Role_ID != 3)
                    {
                        Users user = new Users();
                        user = _userMapper.MapUser(_userBusinessLogic.GetUserByUserId(userId));
                        _userBusinessLogic.DeleteUser(userId);
                        _houseController.AddPoints(-5, user.House_ID);
                        if (userToDelete.Role_ID != 3)
                        {
                            return RedirectToAction("ViewAllUsers", "Users", new { area = "" });
                        }
                        else
                        {
                            return RedirectToAction("ViewUserByUserId", "Users", new { area = "" });
                        }
                    }
                    else
                    {
                        TempData["AdminDelete"] = "Admin cannot be deleted.";
                        if (userToDelete.Role_ID != 3)
                        {
                            return RedirectToAction("ViewAllUsers", "Users", new { area = "" });
                        }
                        else
                        {
                            return RedirectToAction("ViewUserByUserId", "Users", new { area = "" });
                        }
                    }
                }
                else
                {
                    _userBusinessLogic.DeleteUser(userId);
                    _houseController.AddPoints(-5, (int)Session["House_ID"]);
                    return RedirectToAction("Login", "Users", new { area = "" });
                }
            }
            else
            {
                TempData["DeleteSuccess"] = "User has been deleted.";
                return RedirectToAction("Login", "Users", new { area = "" });
            }
        } //Delete for individual users and admin
    }
}