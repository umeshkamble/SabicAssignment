using Assignment1.iOS.Services;
using Assignment1.Services.DependencyServices;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace Assignment1.iOS.Services
{
    public class BaseUrl : IBaseUrl
    {
        public string Get()
        {
            return $"{ NSBundle.MainBundle.BundlePath}/fontawesome5.html";
        }


    }
}