using System;
using System.Collections.Generic;
using System.IO;
using Tasky.Shared.Daos;
using Tasky.Shared.Models;

namespace Tasky.Shared.Repositories 
{
	public class TodoItemRepository 
	{
		TodoDatabaseDao db = null;
		protected static string dbLocation;		
		protected static TodoItemRepository me;		

		static TodoItemRepository ()
		{
			me = new TodoItemRepository();
		}

		protected TodoItemRepository ()
		{
			// set the db location
			dbLocation = DatabaseFilePath;

			// instantiate the database	
			db = new TodoDatabaseDao(dbLocation);
		}

		public static string DatabaseFilePath 
		{
			get 
			{ 
				var sqliteFilename = "TaskDatabase.db3";
				#if NETFX_CORE
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
				#else

				#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
				#else

				#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
				#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
				#endif

				#endif
				return path;	
			}
		}

		public static TodoItem GetTask(int id)
		{
			return me.db.GetItem(id);
		}

		public static IEnumerable<TodoItem> GetTasks ()
		{
			return me.db.GetItems();
		}

		public static int SaveTask (TodoItem item)
		{
			return me.db.AddItem(item);
		}

		public static int DeleteTask(TodoItem item)
		{
			return me.db.DeleteItem(item);
		}
	}
}

