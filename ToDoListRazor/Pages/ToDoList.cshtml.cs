using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using ToDoListLibrary;
using ToDoListRazor.Models;

namespace ToDoListRazor
{
    [Authorize]
    public class ToDoListModel : PageModel
    {
        private readonly ISqlDataAccess _sql;

        public List<ToDoModel> ToDos { get; set;  }

        public ToDoListModel(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void OnGet()
        {
            ToDos = _sql.LoadData<ToDoModel, dynamic>("[dbo].[spToDos_ReadAll]", new 
            { 
                OwnerId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            });
        }
    }
}