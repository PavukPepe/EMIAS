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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using API_Emias;
using API_Emias.Controllers;
using API_Emias.Models;


namespace EMIAS
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        //private Authentication_Window authentication_Window;
        private PatientsController patientsController;
        private DoctorsController doctorsController;
        private AdminProfsController adminController;
        private user_page upage = new user_page();
        private doctor_page dpage = new doctor_page();
        private admin_page apage = new admin_page();


        public AdminWindow()
        {
            InitializeComponent();
            List<string> Users = new List<string>() { "Пользователь", "Врач", "Администратор" };  
            ComboBoxChoiceUser.SelectedItem = 0;
            dataGrid.ItemsSource = (System.Collections.IEnumerable)patientsController.GetPatients();
        }

        private async void AddEntryFunc(int selectedIndex)
        {
            if(selectedIndex == 0)
            {
                Patient patient = new Patient() 
                { 
                    Oms = Convert.ToInt64(upage.PolicynumberTextBox), 
                    SurnamePatient = upage.SurnameTextBox.Text,
                    NamePatient = upage.NameTextBox.Text,
                    PatronymicPatient = upage.PatronymicTextBox.Text,
                    BirthDate = DateOnly.Parse(upage.BirthdatesTextBox.Text),
                    AddressPatient = upage.AddressTextBox.Text
                };
                
                await patientsController.PostPatient(patient);
            }
            else if (selectedIndex == 1)
            {
                Doctor doctor = new Doctor()
                {
                    SurnameDoctor = dpage.SurnameTextBox.Text,
                    NameDoctor = dpage.NameTextBox.Text,
                    PatronymicDoctor = dpage.PatronymicTextBox.Text,
                    IdSpeciality = dpage.SpecialtyComboBox.SelectedIndex,
                    EnterPassword = dpage.AddressTextBox.Text,
                    WorkAddress = dpage.AddressTextBox.Text
                };

                await doctorsController.PostDoctor(doctor);
            }
            else if (selectedIndex == 2)
            {
                AdminProf admin = new AdminProf()
                {
                    SurnameAdmin = apage.SurnameTextBox.Text,
                    NameAdmin = apage.NameTextBox.Text,
                    PatronymicAdmin = apage.PatronymicTextBox.Text,
                    EnterPassword = apage.PasswordTextBox.Text
                };

                await adminController.PostAdminProf(admin);
            }
        }

        private async void ChangeEntryFunc(int selectedIndex, int selectedData)
        {

            if (selectedIndex == 0)
            {
                Patient patient = new Patient()
                {
                    Oms = Convert.ToInt64(upage.PolicynumberTextBox),
                    SurnamePatient = upage.SurnameTextBox.Text,
                    NamePatient = upage.NameTextBox.Text,
                    PatronymicPatient = upage.PatronymicTextBox.Text,
                    BirthDate = DateOnly.Parse(upage.BirthdatesTextBox.Text),
                    AddressPatient = upage.AddressTextBox.Text
                };

                await patientsController.PutPatient((Int64)selectedData, patient);
            }
            else if (selectedIndex == 1)
            {
                Doctor doctor = new Doctor()
                {
                    SurnameDoctor = dpage.SurnameTextBox.Text,
                    NameDoctor = dpage.NameTextBox.Text,
                    PatronymicDoctor = dpage.PatronymicTextBox.Text,
                    IdSpeciality = dpage.SpecialtyComboBox.SelectedIndex,
                    EnterPassword = dpage.AddressTextBox.Text,
                    WorkAddress = dpage.AddressTextBox.Text
                };

                await doctorsController.PutDoctor( selectedData, doctor);
            }
            else if (selectedIndex == 2)
            {
                AdminProf admin = new AdminProf()
                {
                    SurnameAdmin = apage.SurnameTextBox.Text,
                    NameAdmin = apage.NameTextBox.Text,
                    PatronymicAdmin = apage.PatronymicTextBox.Text,
                    EnterPassword = apage.PasswordTextBox.Text
                };

                await adminController.PutAdminProf( selectedData, admin);
            }

        }

        private async void DeleteEntryFunc(int selectedIndex, int selectedData)
        {
            if (selectedIndex == 0)
            {
                await patientsController.DeletePatient((Int64)selectedData);
            }
            else if (selectedIndex == 1)
            {
                await doctorsController.DeleteDoctor(selectedData);
            }
            else if (selectedIndex == 2)
            {
                await adminController.DeleteAdminProf(selectedData);
            }
        }

        private void ComboBoxChoiceUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxChoiceUser.SelectedIndex == 0)
            {
                SelectedUserFrame.Content = new user_page();
                dataGrid.ItemsSource = (System.Collections.IEnumerable)patientsController.GetPatients();
            }
            else if(ComboBoxChoiceUser.SelectedIndex == 1)
            {
                SelectedUserFrame.Content = new doctor_page();
                dataGrid.ItemsSource = (System.Collections.IEnumerable)doctorsController.GetDoctors();
            }
            else if(ComboBoxChoiceUser.SelectedIndex == 2)
            {
                SelectedUserFrame.Content = new admin_page();
                dataGrid.ItemsSource = (System.Collections.IEnumerable)adminController.GetAdminProfs();
            }
        }

        private void AddEntryButton_Click(object sender, RoutedEventArgs e)
        {
            AddEntryFunc(ComboBoxChoiceUser.SelectedIndex);
        }

        private void ChangeEntryButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeEntryFunc(ComboBoxChoiceUser.SelectedIndex, (int)dataGrid.SelectedItems[0]);
        }
        private void DeleteEntryButton_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteEntryFunc(ComboBoxChoiceUser.SelectedIndex, (int)dataGrid.SelectedItems[0]);
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //authentication_Window = new Authentication_Window;
            //Close();
            //authentication_Window.Show();

        }

    }
}
