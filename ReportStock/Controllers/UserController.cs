using Microsoft.AspNetCore.Mvc;
using ReportStock.Models;
using ReportStock.Services;
using System.Data;
using System.Security.Principal;

namespace ReportStock.Controllers
{
	public class UserController : Controller 
	{
		private readonly IConfiguration configuration;
		public List<UserModel> Users = new List<UserModel>();
		UserModel user = new UserModel();
		UserService userService = new UserService();


		public UserController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public IActionResult Index()
		{
			Users = userService.GetUsers(configuration);
			return View(Users);

			//ViewBag.Users = userService.GetUsers(configuration); 
			//return View(ViewBag.Users);
		}
 

		[HttpPost]
		public IActionResult AddUserForm(UserModel user)
		{
			if (string.IsNullOrEmpty(user.username))
			{
				TempData["msg"] = "Please fill UserId .";
				return RedirectToAction();
			}

			user.username = Request.Form["Username"];
			user.password = Request.Form["Password"];
			user.name = Request.Form["Name"];
			user.department = Request.Form["Department"];
			user.status = Request.Form["Status"];


			bool isComplete = false;
			string messageReturn = string.Empty;
			DataSet dsRequestAddAccount = userService.UpdateUser(configuration, user); ;
			ViewBag.IsComplete = dsRequestAddAccount.Tables[0];

			if (dsRequestAddAccount.Tables.Count > 0)
			{
				isComplete = (bool)dsRequestAddAccount.Tables[0].Rows[0]["IsComplete"];
				messageReturn = (string)dsRequestAddAccount.Tables[0].Rows[0]["MessageReturn"];
			}

			//TempData["msg"] = messageReturn; // "Add account successful .";
			return RedirectToAction("User");

		}

		public IActionResult EditUser(Int64 id)
		{
			Users = userService.GetUserById(configuration, id);
			//ViewBag.UserEdit = userService.GetUserById(configuration, id);
			return View(Users);
		}

		[HttpPost]
		public IActionResult UpdateUserForm(UserModel user)
		{
			if (string.IsNullOrEmpty(user.name))
			{
				TempData["msg"] = "Please fill UserId .";
				return View(user);

				//user.errorMessage = "Please fill UserId .";
				//ModelState.AddModelError("Error", "Check Firstname !");
				//return RedirectToAction("EditUser");
			}

			user.id = Convert.ToInt64(Request.Form["Id"]);
			user.username = Request.Form["Username"];
			user.password = Request.Form["Password"];
			user.name = Request.Form["Name"];
			user.department = Request.Form["Department"];
			user.status = Request.Form["Status"];


			bool isComplete = false;
			string messageReturn = string.Empty;
			DataSet dsRequestAddAccount = userService.UpdateUser(configuration, user); ;
			ViewBag.IsComplete = dsRequestAddAccount.Tables[0];

			if (dsRequestAddAccount.Tables.Count > 0)
			{
				isComplete = (bool)dsRequestAddAccount.Tables[0].Rows[0]["IsComplete"];
				messageReturn = (string)dsRequestAddAccount.Tables[0].Rows[0]["MessageReturn"];
			}

			TempData["msg"] = messageReturn; // "Add account successful .";
			return RedirectToAction("User");

		}


		public IActionResult DeleteUser(Int64 id)
		{
			bool isComplete = false;
			string messageReturn = string.Empty;
			DataSet dsRequestAddAccount = userService.DeleteUser(configuration, id); ;
			ViewBag.IsComplete = dsRequestAddAccount.Tables[0];

			if (dsRequestAddAccount.Tables.Count > 0)
			{
				isComplete = (bool)dsRequestAddAccount.Tables[0].Rows[0]["IsComplete"];
				messageReturn = (string)dsRequestAddAccount.Tables[0].Rows[0]["MessageReturn"];
			}

			//TempData["msg"] = messageReturn; // "Add account successful .";
			return RedirectToAction("User");
		}

	}
}
