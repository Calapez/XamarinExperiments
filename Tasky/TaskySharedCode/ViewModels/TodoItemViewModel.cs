using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using Tasky.Shared.Models;
using Tasky.Shared.Repositories;

namespace Tasky.Shared.ViewModels
{
    class TodoItemViewModel : MvxViewModel
    {

		#region Properties
		private ObservableCollection<TodoItem> _todoItemCollection = new ObservableCollection<TodoItem>();
		public ObservableCollection<TodoItem> TodoItemCollection
		{
			get { return _todoItemCollection; }
			set 
			{ 
				_todoItemCollection = value; 
				RaisePropertyChanged(() => TodoItemCollection); 
			}
		}
        #endregion

		#region Methods
		public static TodoItem GetTask(int id)
		{
			return TodoItemRepository.GetTask(id);
		}

		public void GetTasks()
		{
			var items = TodoItemRepository.GetTasks();

			TodoItemCollection.Clear();
			foreach (TodoItem item in items)
            {
				TodoItemCollection.Add(item);
            }
		}

		public static int SaveTask(TodoItem item)
		{
			return TodoItemRepository.SaveTask(item);
		}

		public static int DeleteTask(TodoItem item)
		{
			return TodoItemRepository.DeleteTask(item);
		}
		#endregion
	}
}
