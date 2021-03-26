using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Tasky.Shared.ViewModels;

namespace Tasky.Shared
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<TodoItemListViewModel>();
        }
    }
}
