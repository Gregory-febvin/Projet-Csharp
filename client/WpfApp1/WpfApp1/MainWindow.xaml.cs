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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectSocket(string ip, int port)
        {
            try
            {
                client.Connect(ip, port);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SendSocket(string Mes)
        {
            if (client.Connected)
            {
                byte[] b_Mes = new byte[4096];
                b_Mes = Encoding.UTF8.GetBytes(Mes);
                client.Send(b_Mes);
            }
        }
        private void ResevMessSocket()
        {
            if(client.Connected) { 
            byte[] receiveBuffer = new byte[4096];
            int bytesRead = client.Receive(receiveBuffer);
            string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, bytesRead);
            LabelMessCrypte.Content= receivedMessage;

                
            }
        }

        private void App_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (client.Connected)
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
                        ChaineAScrypte = "C|"+ChaineAScrypte;
                    }
                    else if (CheckVigenere.IsChecked == true)
                    {
                        ChaineAScrypte = "P|" + ChaineAScrypte;
                    }
                    else if (CheckSubsti.IsChecked == true)
                    {
                        ChaineAScrypte = "S|" + ChaineAScrypte;
                    }
                    ConnectSocket("172.18.1.62",6666);
                    SendSocket(ChaineAScrypte);
                    ResevMessSocket();
                    


                }
                else{
                
                    // Afficher un message d'erreur si la chaîne ne contient pas que des lettres majuscules
                    MessageBox.Show("La chaîne doit être composée uniquement de lettres majuscules.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
