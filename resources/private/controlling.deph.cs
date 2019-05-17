using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AspNetCore.SignalR.Client;

namespace ui {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        HubConnection connection;

        private string groupname;

        public MainWindow () {
            InitializeComponent ();

            connection = new HubConnectionBuilder ()
                .WithUrl ("http://localhost:5000/worldhub")
                .Build ();

            connection.Closed += async (error) => {
                await Task.Delay (new Random ().Next (0, 5) * 1000);
                await connection.StartAsync ();
            };
        }

        private async void Connect_Click (object sender, RoutedEventArgs e) {
            string nameSuper = "uskuki";
            connection.On<string, string> ("ReceiveMessage", (user, message) => {
                this.Dispatcher.Invoke (() => {
                    var newMessage = $"{user}: {message}";
                    messagesList.Items.Add (newMessage);
                });
            });

            try {
                await connection.StartAsync ();
                messagesList.Items.Add ("Connection started");
                Connect.IsEnabled = false;
                Send.IsEnabled = true;

                await connection.InvokeAsync ("HandMakeConnection", UserTextBox.Text);
            } catch (Exception ex) {
                messagesList.Items.Add (ex.Message);
            }
        }

        private async void Send_Click (object sender, RoutedEventArgs e) {
            try {
                await connection.InvokeAsync ("Send",
                    UserTextBox.Text, MessageTextBox.Text);
            } catch (Exception ex) {
                messagesList.Items.Add (ex.Message);
            }
        }

        public async void createGroup_Click (object sender, RoutedEventArgs e) {
            groupname = "SuperGroup";
            try {
                await connection.InvokeAsync ("CreateGroup", groupname);
            } catch (Exception exception) {
                Console.WriteLine (exception);
            }
        }
    }
}