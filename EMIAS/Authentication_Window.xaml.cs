using API_Emias.Controllers;
using API_Emias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EMIAS
{
    /// <summary>
    /// Логика взаимодействия для Authentication_Window.xaml
    /// </summary>
    public partial class Authentication_Window : Window
    {
        private Authentication_window_admin authentication_Window_Admin;
        private MainWindow mainWindow;
        private PatientsController patientsController;

        public Authentication_Window()
        {
            InitializeComponent();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {

            foreach (var patients in (System.Collections.IEnumerable)patientsController.GetPatients().Result.Value)
            {
                if (patients.ToString() == NumberPolicyTextBox.Text)
                {
                    mainWindow = new MainWindow();
                    Close();
                    mainWindow.Show();
                }
            }
        }

        private void DoctorButton_Click(object sender, RoutedEventArgs e)
        {
            authentication_Window_Admin = new Authentication_window_admin();
            Close();
            authentication_Window_Admin.Show();
        }

        private void СollapseButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (WindowState)FormWindowState.Minimized;
        }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (WindowState)FormWindowState.Maximized;
        }

        private void ClosedButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
