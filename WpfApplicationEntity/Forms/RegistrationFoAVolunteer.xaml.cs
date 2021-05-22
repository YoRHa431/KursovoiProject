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
    public partial class RegistrationForAVolunteerWindow : Window
    {
        public RegistrationForAVolunteerWindow(bool add_edit, int ID)
        {
            InitializeComponent();
            this.add_edit = add_edit;
            this.EditID = ID;
        }
        private int ID;
        private int EditID;
        private bool add_edit;
        public RegistrationForAVolunteerWindow()
        {
            InitializeComponent();
        }
        public RegistrationForAVolunteerWindow(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }
        private void ButtonAddEditRegistrationForAVolunteer_Click(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
            {
                if (this.add_edit == true)
                    if (date.Text != string.Empty)
                    {
                        WpfApplicationEntity.API.Registration_for_a_volunteer objectRegistrationForAVolunteer = new WpfApplicationEntity.API.Registration_for_a_volunteer();
                        objectRegistrationForAVolunteer.Date = date.Text;
                        try
                        {

                            objectMyDBContext.Registration_for_a_volunteers.Add(objectRegistrationForAVolunteer);
                            objectMyDBContext.SaveChanges();
                            MessageBox.Show("Регистрация волонтёра добавлена");
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
                else
                {
                    var result = objectMyDBContext.Registration_for_a_volunteers.Find(EditID);
                    result.Date = date.Text;
                }
                objectMyDBContext.SaveChanges();
            }
            this.Close();
        }
        private bool IsDataCorrcet()
        {
            return date.Text != string.Empty;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
            {
                WpfApplicationEntity.API.Registration_for_a_volunteer naz = new WpfApplicationEntity.API.Registration_for_a_volunteer();
                if (add_edit == false)
                {
                    ButtonAddEditGroup.Content = "Сохранить";
                    naz = objectMyDBContext.Registration_for_a_volunteers.Find(EditID);
                    date.Text = naz.Date;
                }
            }
        }
    }
}
