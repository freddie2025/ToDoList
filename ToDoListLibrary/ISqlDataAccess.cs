using System.Collections.Generic;

namespace ToDoListLibrary
{
	public interface ISqlDataAccess
	{
		List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName = "ToDoListDB");
		void SaveData<T>(string storedProcedure, T parameters, string connectionStringName = "ToDoListDB");
	}
}