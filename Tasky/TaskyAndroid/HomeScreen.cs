using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using TaskyAndroid.ApplicationLayer;
using Android.Content.PM;
using System;
using Tasky.Shared.ViewModels;
using System.Collections.Specialized;

namespace TaskyAndroid.Screens 
{
	/// <summary>
	/// Main ListView screen displays a list of tasks, plus an [Add] button
	/// </summary>
	[Activity (Label = "Tasky",  
		Icon="@drawable/icon",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class HomeScreen : Activity
	{
		TodoItemViewModel viewModel;

		TodoItemListAdapter taskList;
		Button addTaskButton;
		ListView taskListView;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.HomeScreen);

			// Initialize view model
			viewModel = new TodoItemViewModel();

			//Find our controls
			taskListView = FindViewById<ListView> (Resource.Id.TaskList);
			addTaskButton = FindViewById<Button> (Resource.Id.AddButton);

			// wire up add task button handler
			if(addTaskButton != null) {
				addTaskButton.Click += (sender, e) => {
					StartActivity(typeof(TodoItemScreen));
				};
			}
			
			// wire up task click handler
			if(taskListView != null) {
				taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var taskDetails = new Intent (this, typeof (TodoItemScreen));
					taskDetails.PutExtra ("TaskID", viewModel.TodoItemCollection[e.Position].ID);
					StartActivity (taskDetails);
				};
			}
		}
		
		protected override void OnResume ()
		{
			base.OnResume();

			// create our adapter
			taskList = new TodoItemListAdapter(this, viewModel.TodoItemCollection);

			//Hook up our adapter to our ListView
			taskListView.Adapter = taskList;

			viewModel.GetTasks();

			viewModel.TodoItemCollection.CollectionChanged += OnItemCollectionChanged;
		}

		private void OnItemCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
			Console.WriteLine("collection changed");
		}

	}
}