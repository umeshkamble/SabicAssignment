using Assignment1.Services.DependencyServices;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1.Views
{
    public partial class RitchTextPage : ContentPage
    {
        public RitchTextPage()
        {
            InitializeComponent();
            webView.Source = new HtmlWebViewSource();
            webView.Source = DependencyService.Get<IBaseUrl>().Get();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var data = await webView.EvaluateJavaScriptAsync($"document.getElementById('content').value;");
        }
    }
}