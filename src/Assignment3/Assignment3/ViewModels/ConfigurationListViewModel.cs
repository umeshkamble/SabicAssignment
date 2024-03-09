using Assignment3.Helpers;
using Assignment3.Models;
using Assignment3.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment3.ViewModels
{
    public class ConfigurationListViewModel : BaseViewModel
    {
        #region Propertise
        private ObservableCollection<FormFields> formFieldList;
        public ObservableCollection<FormFields> FormFieldList
        {
            get => formFieldList;
            set => SetProperty(ref formFieldList, value);
        }
        public Command PreviewFormCommand { get; }
        public Command AddItemCommand { get; }
        public Command<FormFields> EditFormCommand { get; }
        public Command<FormFields> DeleteFormCommand { get; }

        #endregion

        #region Constructor
        public ConfigurationListViewModel()
        {
            Title = "Configuration Form List";
            PreviewFormCommand = new Command(async () => await NavigateToPreview());
            AddItemCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(ConfigurationPage)));
            EditFormCommand = new Command<FormFields>((item) => OnItemSelected(item, "edit"));
            DeleteFormCommand = new Command<FormFields>((item) => OnItemSelected(item, "delete"));
        }

        #endregion

        #region Methods
        public async void OnAppearing()
        {
            IsBusy = true;
            var formFields = await App.Database.GetFieldsAsync();
            if (formFields == null || formFields.Count == 0)
                return;
            FormFieldList = new ObservableCollection<FormFields>(formFields);
        }
        
        private async Task NavigateToPreview()
        {
            bool isEnglish = await Shell.Current.DisplayAlert("Alert", "Do you want to deleted control", "English", "Arabic");
            if (isEnglish)
            {
                CultureInfo language = new CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = language;
                AppConstants.IsEnglishLang = true;
            }
            else
            {
                CultureInfo language = new CultureInfo("ar");
                Thread.CurrentThread.CurrentUICulture = language;
                AppConstants.IsEnglishLang = false;
            }
            await Shell.Current.GoToAsync(nameof(PreviewFormPage));
        }
        async void OnItemSelected(FormFields item, string operation)
        {
            if (item == null)
                return;

            if (operation.Contains("edit"))
            {
                await Shell.Current.GoToAsync($"{nameof(ConfigurationPage)}?{nameof(ConfigurationViewModel.FormId)}={item.Id}");
            }
            else
            {
                bool result = await Shell.Current.DisplayAlert("Alert", "Do you want to deleted control", "Yes", "No");
                if (result)
                {
                    await App.Database.DeleteFieldsAsync(item);
                    FormFieldList.Remove(item);
                }
            }
        }
        #endregion
    }
}