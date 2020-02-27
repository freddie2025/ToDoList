using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListLibrary;

namespace ToDoListRazor
{
    public class CreateToDoModel : PageModel
    {
        private readonly ISqlDataAccess _sql;

        [BindProperty]
        public string ToDoText { get; set; }

        [BindProperty]
        public bool IsComplete { get; set; }

        public CreateToDoModel(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
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