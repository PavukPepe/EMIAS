using API_Emias.Controllers;
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
    /// Логика взаимодействия для Authentication_window_admin.xaml
    /// </summary>
    public partial class Authentication_window_admin : Window
    {
        AdminWindow adminWindow;
        MainWindow mainWindow;
        private Authentication_Window authentication_Window;
        private DoctorsController doctorsController;
        private AdminProfsController adminProfsController;
        public Authentication_window_admin()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void СollapseButton_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState)FormWindowState.Minimized;
        }

        private void ExpandButton_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState)FormWindowState.Maximized;
        }

        private void ClosedButton_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SignButton_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var doctors in (System.Collections.IEnumerable)doctorsController.GetDoctors().Result.Value.ToList())
            {
                if (doctors.ToString() == NumberEployerTextBox.Text)
                {
                    mainWindow = new MainWindow();
                    Close();
                    mainWindow.Show();
                }
            }
            foreach (var admins in (System.Collections.IEnumerable)adminProfsController.GetAdminProfs().Result.Value.ToList())
            {
                if (admins.ToString() == NumberEployerTextBox.Text)
                {
                    adminWindow = new AdminWindow();
                    Close();
                    adminWindow.Show();
                }
            }
        }

        private void PatientButton_Click_1(object sender, RoutedEventArgs e)
        {
            authentication_Window = new Authentication_Window();
            Close();
            authentication_Window.Show();
        }
    }
}
