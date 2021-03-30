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
using System.Windows.Shapes;

namespace WpfApplicationEntity.Forms
{
    /// <summary>
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class VolunteerWindow : Window
    {
        private bool add_edit;
        public VolunteerWindow()
        {
            InitializeComponent();
        }
        public VolunteerWindow(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }

        private void ButtonAddEditVolunteer_Click(object sender, RoutedEventArgs e)
        {
            if (this.add_edit == true)
                if (textBlockAddEditAddres.Text != string.Empty
                    && textBlockAddEditBirthday.Text != string.Empty
                    && textBlockAddEditMiddleName.Text != string.Empty
                    && textBlockAddEditSurname.Text != string.Empty
                    && textBlockAddEditLastName.Text != string.Empty
                    && textBlockAddEditLogin.Text != string.Empty
                    && textBlockAddEditPassword.Text != string.Empty
                    && textBlockAddEditNumberPhone.Text != string.Empty
                    && textBlockAddEditGenus.Text != string.Empty)
                {
                    WpfApplicationEntity.API.Volunteer objectVolunteer = new WpfApplicationEntity.API.Volunteer();
                    objectVolunteer.Addres = textBlockAddEditAddres.Text;
                    objectVolunteer.DateOfBirth = textBlockAddEditBirthday.Text;
                    objectVolunteer.MiddleName = textBlockAddEditMiddleName.Text;
                    objectVolunteer.SurName = textBlockAddEditSurname.Text;
                    objectVolunteer.LastName = textBlockAddEditLastName.Text;
                    objectVolunteer.Login = textBlockAddEditLogin.Text;
                    objectVolunteer.Password = textBlockAddEditPassword.Text;
                    objectVolunteer.PhoneNumber = textBlockAddEditNumberPhone.Text;
                    objectVolunteer.Genus = textBlockAddEditGenus.Text;
                    try
                    {
                        using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                        {
                            objectMyDBContext.Volunteers.Add(objectVolunteer);
                            objectMyDBContext.SaveChanges();
                        }
                        MessageBox.Show("Волонтёр добавлен");
                        this.DialogResult = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка!");
                    this.DialogResult = false;
                }
        }
    }
}
