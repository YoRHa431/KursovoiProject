using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplicationEntity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
                {

                    if (objectMyDBContext.Database.Exists() == false)
                    {
                        objectMyDBContext.Database.Create();
                        //WpfApplicationEntity.API.User objectUser = new WpfApplicationEntity.API.User();
                        //objectUser.Name = "user name";
                        //objectUser.Login = "user";
                        //objectUser.Password = "1111";
                        //objectMyDBContext.Users.Add(objectUser);
                        //objectMyDBContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            //this.ShowAll();
        }
        private void ShowAll()
        {
            
        }

        private void addVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.VolunteerWindow g = new Forms.VolunteerWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.NeedyWindow g = new Forms.NeedyWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addActionButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.ActionWindow g = new Forms.ActionWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addServiceButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.ServiceWindow g = new Forms.ServiceWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addTypeActionButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.TypeActionWindow g = new Forms.TypeActionWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addTypeServiceButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.TypeServiceWindow g = new Forms.TypeServiceWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addRegistationForAVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.RegistrationForAVolunteerWindow g = new Forms.RegistrationForAVolunteerWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addRegistationForANeedsButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.RegistrationForANeedsWindow g = new Forms.RegistrationForANeedsWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }
    }
}
