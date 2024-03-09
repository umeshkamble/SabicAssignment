using Assignment3.Models;
using Assignment3.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment3.ViewModels
{
    [QueryProperty(nameof(FormId), nameof(FormId))]
    public class ConfigurationViewModel : BaseViewModel
    {
        #region Propertise

        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }

        private FormFields formField;

        public FormFields FormField
        {
            get => formField;
            set => SetProperty(ref formField, value);
        }
        private ControlTypes selectedControl;

        public ControlTypes SelectedControl
        {
            get => selectedControl;
            set => SetProperty(ref selectedControl, value);
        }

        private int formId;
        public int FormId
        {
            get
            {
                return formId;
            }
            set
            {
                formId = value;
                LoadByControlId(value);
            }
        }

        public ObservableCollection<ControlTypes> ControlsList { get; }
        public IDataStore<ControlTypes> DataStore => DependencyService.Get<IDataStore<ControlTypes>>();
        #endregion

        #region Constructor
        public ConfigurationViewModel()
        {
            Title = "Configuration Form";
            FormField = new FormFields();
            ControlsList = new ObservableCollection<ControlTypes>();
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
            SaveCommand = new Command(async () => await ExecuteSaveCommand());
        }

        #endregion

        #region Binding
        public async void OnAppearing()
        {
            IsBusy = true;
            try
            {
                ControlsList.Clear();
                var controls = await DataStore.GetControlsAsync();
                foreach (var control in controls)
                {
                    ControlsList.Add(control);
                }
                SelectedControl = ControlsList[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void LoadByControlId(int itemId)
        {
            try
            {
                if (itemId == 0)
                    return;
                var formData = await App.Database.GetFieldsAsync(itemId);
                if (formData != null)
                {
                    FormField = formData;
                    SelectedControl= await DataStore.GetControlAsync(formData.ControlType);
                }

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");

            }
        }
        #endregion

        #region Command
        private async Task ExecuteSaveCommand()
        {
            try
            {
                FormField.ControlType = SelectedControl.Name;
                await App.Database.SaveFieldsAsync(FormField);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        #endregion
    }
}