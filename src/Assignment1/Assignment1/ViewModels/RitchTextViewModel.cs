using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assignment1.ViewModels
{
    public class RitchTextViewModel : BaseViewModel
    {
        public RitchTextViewModel()
        {
            Title = "Ritch Text Box";
            RitchTextCommand = new Command<string>(async (operation) => await RitchTextOperation(operation));
        }

        public ICommand RitchTextCommand { get; }

        private async Task RitchTextOperation(string operation)
        {
            try
            {
                await Task.Delay(500);

                switch (operation)
                {
                    case "bold":
                        await Task.Delay(500);
                        break;
                    case "Italic":
                        await Task.Delay(500);
                        break;
                    case "underline":
                        await Task.Delay(500);
                        break;
                    case "table":
                        await Task.Delay(500);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}