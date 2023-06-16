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
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private string ip = "172.0.0.1"; //ip du serveur socket
        private int port = 6666; //Port d'écoute serveur socket

        public MainWindow()
        {
            InitializeComponent();
        }

        //pour se connecter au serveur
        private void ConnectSocket(string ip, int port)
        {
            try
            {
                client.Connect(ip, port);
            }
            catch (Exception ex)   //en cas d'erreur de connection
            {
                Console.WriteLine(ex.Message);
            }
        }
        //pour envoyer quelle que chose au serveur
        private void SendSocket(string Mes)
        {
            if (client.Connected)
            {
                byte[] b_Mes = new byte[4096];
                b_Mes = Encoding.UTF8.GetBytes(Mes);
                client.Send(b_Mes);
            }
        }

        //quand le client reçois quelle que chose du serveur
        private void ResevMessSocket()
        {
            if (client.Connected)
            {
                byte[] receiveBuffer = new byte[4096];
                int bytesRead = client.Receive(receiveBuffer); //récupération des donné
                string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, bytesRead); //conversion des donné en string
                LabelMessCrypte.Content = receivedMessage;

                //si la réponse du serveur est != vide on active pas le bouton copy
                if(receivedMessage != null)
                
                    Button_copy.IsEnabled= true;
                else
                    Button_copy.IsEnabled= false;


            }
        }

        //quand l'utilisateur appui sur le bouton de fermeture 
        private void App_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (client.Connected) //detect si le client est connecter au serveur
            {
                //déconection du socket a la fermeur de l'application
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }

        }

        private void txtInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string ChaineAScrypte = txtInput.Text.ToUpper().Replace(" ", ""); // Convertir en majuscules et supprimer les espaces

                // Vérifier si la chaîne est conforme à l'expression régulière
                if (Regex.IsMatch(ChaineAScrypte, @"^[A-Z]+$"))
                {
                    // Appeler le service de chiffrement en fonction du radio-bouton sélectionné
                    if (CheckCesar.IsChecked == true)
                    {
                        ChaineAScrypte = "C|" + ChaineAScrypte;
                    }
                    else if (CheckVigenere.IsChecked == true)
                    {
                        ChaineAScrypte = "P|" + ChaineAScrypte;
                    }
                    else if (CheckSubsti.IsChecked == true)
                    {
                        ChaineAScrypte = "S|" + ChaineAScrypte;
                    }
                    ConnectSocket(ip, port);
                    SendSocket(ChaineAScrypte);
                    ResevMessSocket();
                }
                else
                {

                    // Afficher un message d'erreur si la chaîne ne contient pas que des lettres majuscules
                    MessageBox.Show("La chaîne doit être composée uniquement de lettres.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        //losque que l'utilisateur clique sur le bouton copie pour copier la chaîne Crypté
        private async void Click_Copy(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(LabelMessCrypte.Content.ToString());
            Button_copy.Content = "Copié !";
            Button_copy.FontWeight= FontWeights.Bold;
            await Task.Delay(2000); //ajout d'un délai de 2 seconde
            Button_copy.Content = "Copie";
            Button_copy.FontWeight = FontWeights.Normal;

        }
    }
}
