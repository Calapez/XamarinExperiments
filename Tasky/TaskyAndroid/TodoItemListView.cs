using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using TaskyAndroid.ApplicationLayer;
using Android.Content.PM;
using System;
using Tasky.Shared.ViewModels;
using System.Collections.Specialized;
using MvvmCross.Platforms.Android.Views;

namespace TaskyAndroid.Screens 
{
	/// <summary>
	/// Main ListView screen displays a list of tasks, plus an [Add] button
	/// </summary>
	[Activity(Label = "Home Screen", ScreenOrientation = ScreenOrientation.Portrait)]
	public class TodoItemListView : MvxActivity
	{
		Button addTaskButton;

        protected override void OnViewModelSet()
        {
			SetContentView(Resource.Layout.HomeScreen);
			
			//Find our controls
			addTaskButton = FindViewById<Button>(Resource.Id.AddButton);

			// wire up add task button handler
			if (addTaskButton != null)
			{
				addTaskButton.Click += (sender, e) => {
					StartActivity(typeof(TodoItemScreen));
				};
			}
		}

        protected override void OnResume ()
		{
			base.OnResume();

			//viewModel.GetTasks();

			//viewModel.TodoItemCollection.CollectionChanged += OnItemCollectionChanged;
		}

	}
}