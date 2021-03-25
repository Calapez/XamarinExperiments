using System.Collections.Generic;
using Tasky.Shared.Models;
using Tasky.Shared.Repositories;

namespace Tasky.Shared 
{
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public static class TodoItemManager 
	{
		
		public static TodoItem GetTask(int id)
		{
			return TodoItemRepository.GetTask(id);
		}
		
		public static IList<TodoItem> GetTasks ()
		{
			return new List<TodoItem>(TodoItemRepository.GetTasks());
		}
		
		public static int SaveTask (TodoItem item)
		{
			return TodoItemRepository.SaveTask(item);
		}
		
		public static int DeleteTask(int id)
		{
			return TodoItemRepository.DeleteTask(id);
		}
	}
}