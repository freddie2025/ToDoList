using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoListLibrary;
using ToDoListRazor.Models;

namespace ToDoListRazor
{
    [Authorize(Roles = "Administrator")]
    public class UserManagementModel : PageModel
    {
        private readonly ISqlDataAccess _sql;

        public List<UserModel> Users { get; set; } 
        public SelectList UserDropDownData{  get; set; }

        [BindProperty]
        public string IdToModify { get; set; }

        [BindProperty]
        public int PermittedToDoCount { get; set; }

        public UserManagementModel(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void OnGet()
        {
            Users = _sql.LoadData<UserModel, dynamic>("[dbo].[spUsers_ReadAll]", new { });

            UserDropDownData = new SelectList(Users, nameof(UserModel.Id), nameof(UserModel.UserEmail));
        }

        public IActionResult OnPost()
        {
            _sql.SaveData("[dbo].[spUsers_Update]", new
            {
                Id = IdToModify,
                PermittedToDoCount
            });

            return RedirectToPage("./UserManagement");
        }
    }
}