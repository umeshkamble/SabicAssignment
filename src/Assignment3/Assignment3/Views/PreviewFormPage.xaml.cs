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
                        Text = form.LabelEnglish
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
                            Placeholder = form.LabelEnglish,
                            MaxLength=form.MaxSizeEn
                            
                        };
                        content.Children.Add(txtEntry);
                        break;
                    case "editor":
                        var txtEditor = new Editor
                        {
                            Placeholder = form.LabelEnglish,
                            HeightRequest = 100,
                            MaxLength= form.MaxSizeEn
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
                            Text = form.LabelEnglish
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