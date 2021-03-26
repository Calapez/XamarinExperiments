using Android.App;
using Android.Content;
using Android.Runtime;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using System;
using Tasky.Shared;

namespace TaskyAndroid
{
    [Application]
    public class Setup : MvxAndroidApplication<MvxAndroidSetup<App>, App>
    {
        public Setup(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}