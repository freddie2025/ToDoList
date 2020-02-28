using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListLibrary;
using ToDoListRazor.Models;

namespace ToDoListRazor
{
    [Authorize]
    public class CreateToDoModel : PageModel
    {
        private readonly ISqlDataAccess _sql;

        [BindProperty]
        public string ToDoText { get; set; }

        [BindProperty]
        public bool IsComplete { get; set; }

        public string ErrorMessgae { get; set; }

        public CreateToDoModel(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            CanCreateToDoModel canCreate = _sql.LoadData<CanCreateToDoModel, dynamic>(
                    "[dbo].[spToDos_CanCreate]"
                    , new { UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value }
                ).FirstOrDefault();

            if (canCreate.TotalToDos >= canCreate.PermittedToDoCount)
            {
                ErrorMessgae = "You have reached your maximum number of ToDos";
                return Page();
            }
                    
            _sql.SaveData("[dbo].[spToDos_Create]", new 
            { 
                ToDoText, 
                IsComplete, 
                OwnerId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            });

            return RedirectToPage("./ToDoList");
        }
    }
}