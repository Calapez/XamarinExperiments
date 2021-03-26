using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasky.Shared.ViewModels;

namespace Tasky.Shared
{
    public class AppStart : MvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;

        public AppStart(
            IMvxApplication application,
            IMvxNavigationService navigationService,
            object authService)
            : base(application, navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            await _navigationService.Navigate<TodoItemListViewModel>();
        }
    }
}
