using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assignment4.ViewModels
{
    public class ChatRoomViewModel : BaseViewModel
    {
        #region Propertise
        public ICommand SendCommand { get; }
        private readonly HubConnection connection;

        private string chatMessage;

        public string ChatMessage
        {
            get { return chatMessage; }
            set { SetProperty(ref chatMessage, value); }
        }

        private ObservableCollection<string> receivedMessages;

        public ObservableCollection<string> ReceivedMessages
        {
            get { return receivedMessages; }
            set { SetProperty(ref receivedMessages, value); }
        }


        #endregion

        #region Constructor
        public ChatRoomViewModel()
        {
            Title = "Chat Room";
            SendCommand = new Command(async () => await ExecuteSendChat());
            receivedMessages = new ObservableCollection<string>();

            try
            {
                connection = new HubConnectionBuilder()
                .WithUrl("http://172.20.10.10:5033/chat")
                .Build();

                connection.On<string>("ChatReceived", (message) =>
                {
                    Device.BeginInvokeOnMainThread(() => ReceivedMessages.Add(message));
                });

                Task.Run(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>await connection.StartAsync());
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
        #endregion

        #region Commands
        async Task ExecuteSendChat()
        {
            await connection.InvokeCoreAsync("SendMessage", args: new[] { ChatMessage });

            ChatMessage = String.Empty;
        }
        #endregion
    }
}