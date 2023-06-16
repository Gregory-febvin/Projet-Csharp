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

        private void txtInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string input = txtInput.Text.ToUpper().Replace(" ", ""); // Convertir en majuscules et supprimer les espaces

                // Vérifier si la chaîne est conforme à l'expression régulière
                if (Regex.IsMatch(input, @"^[A-Z]+$"))
                {
                    // Appeler le service de chiffrement en fonction du radio-bouton sélectionné
                    if (rbCesar.IsChecked == true)
                    {
                        
                    }
                    else if (rbVigenere.IsChecked == true)
                    {
                        
                        
                    }
                    else if (rbAES.IsChecked == true)
                    {
                        
                    }
                }
                else{
                
                    // Afficher un message d'erreur si la chaîne ne contient pas que des lettres majuscules
                    MessageBox.Show("La chaîne doit être composée uniquement de lettres majuscules.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
