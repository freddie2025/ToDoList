using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListRazor.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string UserEmail { get; set; }
		public int PermittedToDoCount { get; set; }
	}
}
