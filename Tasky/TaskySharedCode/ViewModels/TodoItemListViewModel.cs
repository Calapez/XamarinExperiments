using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tasky.Shared.Models;
using Tasky.Shared.Repositories;

namespace Tasky.Shared.ViewModels
{
    public class TodoItemListViewModel : MvxViewModel
    {

		readonly IMvxNavigationService NavigationService;

		public TodoItemListViewModel()
        {
			NavigationService = Mvx.IoCProvider.GetSingleton<IMvxNavigationService>();
			TodoItemCollection = new List<TodoItem>();

			GetTasks();
		}

		#region Properties
		private List<TodoItem> _todoItemCollection;
		public List<TodoItem> TodoItemCollection
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
			TodoItemCollection.Clear();
			foreach (TodoItem item in DefaultItems())
			{
				TodoItemCollection.Add(item);
			}

			/*
			var items = TodoItemRepository.GetTasks();

			TodoItemCollection.Clear();
			foreach (TodoItem item in items)
            {
				TodoItemCollection.Add(item);
            }
			*/
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

		public List<TodoItem> DefaultItems()
		{
			var item1 = new TodoItem();
			item1.ID = 10;
			item1.Name = "Name 10";
			item1.Notes = "Notes 10";
			item1.Done = false;

			var item2 = new TodoItem();
			item2.ID = 20;
			item2.Name = "Name 20";
			item2.Notes = "Notes 20";
			item2.Done = true;

			var item3 = new TodoItem();
			item3.ID = 30;
			item3.Name = "Name 30";
			item3.Notes = "Notes 30";
			item3.Done = true;

			var item4 = new TodoItem();
			item4.ID = 40;
			item4.Name = "Name 40";
			item4.Notes = "Notes 40";
			item4.Done = false;

			return new List<TodoItem>()
		{
			item1,
			item2,
			item3, 
			item4
		};

		}
	}

	/*
	public class TodoItemElement : TodoItem
    {
		public TodoItemElement(TodoItemListViewModel parent) : base()
        {
			//OpenCommand = new MvxCommand(() => parent.NavigationService.Navigate(nameof(TodoItemDetailsViewModel)));
        }

		public ICommand OpenCommand { get; private set; }

    }
	*/
}
