using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows;
using ui.Environment.UserDomain;

namespace ProcessComponents.EndLoaders
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class NetworkLoader
    {
        private HubConnection hubConnection;
        private EnteredUser enteredUser;

        public NetworkLoader()
        {
            this.connectToDepthServer();
        }

        private void connectToDepthServer()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/worldHub")
                .Build();
            this.cnnErrorDepthServer();
            enteredUser = new EnteredUser();

        }

        private async void cnnErrorDepthServer()
        {
            hubConnection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await hubConnection.StartAsync();
            };
        }

        public async void autoConnectionDepthServer()
        {
            try
            {
                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("HandMakeConnection", enteredUser.Username);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
