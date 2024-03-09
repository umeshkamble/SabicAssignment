using Assignment3.Helpers;
using Assignment3.ViewModels;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Assignment3.Views
{
    public partial class PreviewFormPage : ContentPage
    {
        public PreviewFormPage()
        {
            InitializeComponent();
            BindingContext = new PreviewFormViewModel();
            if (AppConstants.IsEnglishLang)
                FlowDirection = FlowDirection.LeftToRight;
            else FlowDirection = FlowDirection.RightToLeft;
            BuildPreviewForm();
        }

        private async void BuildPreviewForm()
        {
            var content = new StackLayout();
            var formFields = await App.Database.GetFieldsAsync();
            foreach (var form in formFields.OrderBy(x => x.DisplayOrder))
            {
                var control = form.ControlType.ToLower();
                if (!control.Contains("button"))
                {

                    var title = new Label
                    {
                        Text = AppConstants.IsEnglishLang? form.LabelEnglish: form.LabelArabic,
                    };
                    if (form.IsMandatory)
                    {
                        var stackLayout = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(title);
                        var label = new Label
                        {
                            Text = "*",
                            TextColor = Color.Red,
                        };
                        stackLayout.Children.Add(label);
                        content.Children.Add(stackLayout);
                    }
                    else
                        content.Children.Add(title);
                }
                switch (control)
                {
                    case "entry":

                        var txtEntry = new Entry
                        {
                            Placeholder = AppConstants.IsEnglishLang ? form.LabelEnglish : form.LabelArabic,
                            MaxLength = AppConstants.IsEnglishLang ? form.MaxSizeEn: form.MaxSizeAr,

                        };
                        content.Children.Add(txtEntry);
                        break;
                    case "editor":
                        var txtEditor = new Editor
                        {
                            Placeholder = AppConstants.IsEnglishLang ? form.LabelEnglish : form.LabelArabic,
                            HeightRequest = 100,
                            MaxLength = AppConstants.IsEnglishLang ? form.MaxSizeEn : form.MaxSizeAr
                        };
                        content.Children.Add(txtEditor);
                        break;
                    case "picker":

                        var picker = new Picker();
                        content.Children.Add(picker);
                        break;
                    case "checkbox":

                        var checkbox = new CheckBox();
                        content.Children.Add(checkbox);
                        break;
                    case "switch":

                        var switchcontrol = new Switch();
                        content.Children.Add(switchcontrol);
                        break;
                    case "button":

                        var button = new Button
                        {
                            Text = AppConstants.IsEnglishLang ? form.LabelEnglish : form.LabelArabic
                        };
                        content.Children.Add(button);
                        break;
                    default: break;
                }

                scrlRootView.Content = content;
            }
        }
    }
}