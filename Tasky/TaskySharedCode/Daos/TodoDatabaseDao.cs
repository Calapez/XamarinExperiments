using System;
using System.Collections.Generic;
using Tasky.Shared.Models;
using SQLite;

namespace Tasky.Shared.Daos
{
	/// <summary>
	/// TaskDatabase uses ADO.NET to create the [Items] table and create,read,update,delete data
	/// </summary>
	public class TodoDatabaseDao 
	{
		public SQLiteConnection connection;

		public TodoDatabaseDao (string dbPath) 
		{
			connection = new SQLiteConnection(dbPath);
			connection.CreateTable<TodoItem>();
		}

		public IEnumerable<TodoItem> GetItems ()
		{
			try
            {
				return connection.Table<TodoItem>().ToList();
            }
			catch (Exception e)
            {
				Console.WriteLine(e.StackTrace);
            }

			return new List<TodoItem>();
		}

		public TodoItem GetItem (int id) 
		{
			return connection.Find<TodoItem>(id);
		}

		public int AddItem (TodoItem item) 
		{
			int result;
			if (ContainsItem(item))
            {
				result = connection.Update(item);
				Console.WriteLine(string.Format("{0} record(s) updated;)", result));
			} 
			else
			{
				result = connection.Insert(item);
				Console.WriteLine(string.Format("{0} record(s) added;)", result));
			}

			return result;
		}

		public int DeleteItem(TodoItem item) 
		{
			int result = connection.Delete(item);

			Console.WriteLine(string.Format("{0} record(s) deleted;)", result));
			return result;
		}

		private bool ContainsItem(TodoItem item)
        {
			var queryResuly = connection.Table<TodoItem>().Where(i => i.ID == item.ID);
			return queryResuly.Count() > 0;
		}
	}
}