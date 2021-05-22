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
    public partial class RegistrationForANeedsWindow : Window
    {
        public RegistrationForANeedsWindow(bool add_edit, int ID)
        {
            InitializeComponent();
            this.add_edit = add_edit;
            this.EditID = ID;
        }
        private int ID;
        private int EditID;
        private bool add_edit;
        public RegistrationForANeedsWindow()
        {
            InitializeComponent();
        }
        public RegistrationForANeedsWindow(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }
        private void ButtonAddEditRegistrationForANeeds_Click(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
            {
                if (this.add_edit == true)
                    if (plannedDate.Text != string.Empty
                        && applicationDate.Text != string.Empty
                        && actualDate.Text != string.Empty
                        && registrationDate.SelectedIndex != -1)
                    {
                        WpfApplicationEntity.API.Registration_for_a_needs objectRegistrationForANeeds = new WpfApplicationEntity.API.Registration_for_a_needs();
                        objectRegistrationForANeeds.PlannedDate = plannedDate.Text;
                        objectRegistrationForANeeds.ApplicationDate = applicationDate.Text;
                        objectRegistrationForANeeds.ActualDate = actualDate.Text;
                        objectRegistrationForANeeds.Registration_for_a_volunteer = GetRegistrationForAVolunteer(objectMyDBContext.Registration_for_a_volunteers.ToList());
                        try
                        {

                            objectMyDBContext.Registration_for_a_needss.Add(objectRegistrationForANeeds);
                            objectMyDBContext.SaveChanges();
                            MessageBox.Show("Регистрация нуждающегося добавлена");
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
                    var result = objectMyDBContext.Registration_for_a_needss.Find(EditID);
                    result.PlannedDate = plannedDate.Text;
                    result.ApplicationDate = applicationDate.Text;
                    result.ActualDate = actualDate.Text;
                    result.Registration_for_a_volunteer = GetRegistrationForAVolunteer(objectMyDBContext.Registration_for_a_volunteers.ToList());
                }
                objectMyDBContext.SaveChanges();
            }
            this.Close();
        }
        private bool IsDataCorrcet()
        {
            return plannedDate.Text != string.Empty
                    && applicationDate.Text != string.Empty
                    && actualDate.Text != string.Empty;
        }
        private WpfApplicationEntity.API.Registration_for_a_volunteer GetRegistrationForAVolunteer(List<WpfApplicationEntity.API.Registration_for_a_volunteer> list)
        {
            foreach (var item in list)
            {
                if (item.Date == this.registrationDate.SelectedItem.ToString())
                    return item;
            }
            return list[0];
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
            {
                WpfApplicationEntity.API.Registration_for_a_needs naz = new WpfApplicationEntity.API.Registration_for_a_needs();
                List<string> list = new List<string>();
                var actions = objectMyDBContext.Registration_for_a_volunteers.ToList();
                foreach (var item in actions)
                {
                    list.Add(item.Date);
                }
                registrationDate.ItemsSource = list;
                if (add_edit == false)
                {
                    ButtonAddEditGroup.Content = "Сохранить";
                    naz = objectMyDBContext.Registration_for_a_needss.Find(EditID);
                    plannedDate.Text = naz.PlannedDate;
                    applicationDate.Text = naz.ApplicationDate;
                    actualDate.Text = naz.ActualDate;
                    registrationDate.Text = naz.Registration_for_a_volunteer.Date;
                }
            }
        }
    }
}
