using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace TaskyAndroid
{
    [Activity(Label = "Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
        public SplashScreenActivity()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}