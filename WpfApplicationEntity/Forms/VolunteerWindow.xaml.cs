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
        public VolunteerWindow(bool add_edit, int ID)
        {
            InitializeComponent();
            this.add_edit = add_edit;
            this.EditID = ID;
        }
        private int EditID;
        private void ButtonAddEditVolunteer_Click(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
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
                        && textBlockAddEditGenus.Text != string.Empty
                        && comboBlockAddEditActionForTheNeedy.SelectedIndex != -1
                        && comboBlockAddEditRegistrationForAVolunteer.SelectedIndex != -1)
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
                        objectVolunteer.Action_for_the_needy = GetActionForTheNeedy(objectMyDBContext.Action_for_the_needys.ToList());
                        objectVolunteer.Registration_for_a_volunteer = GetRegistrationForAVolunteer(objectMyDBContext.Registration_for_a_volunteers.ToList());
                        try
                        {

                            objectMyDBContext.Volunteers.Add(objectVolunteer);
                            objectMyDBContext.SaveChanges();
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
                else
                {
                    var result = objectMyDBContext.Volunteers.Find(EditID);
                    result.Addres = textBlockAddEditAddres.Text;
                    result.DateOfBirth = textBlockAddEditBirthday.Text;
                    result.MiddleName = textBlockAddEditMiddleName.Text;
                    result.SurName = textBlockAddEditSurname.Text;
                    result.LastName = textBlockAddEditLastName.Text;
                    result.Login = textBlockAddEditLogin.Text;
                    result.Password = textBlockAddEditPassword.Text;
                    result.PhoneNumber = textBlockAddEditNumberPhone.Text;
                    result.Genus = textBlockAddEditGenus.Text;
                    result.Action_for_the_needy = GetActionForTheNeedy(objectMyDBContext.Action_for_the_needys.ToList());
                    result.Registration_for_a_volunteer = GetRegistrationForAVolunteer(objectMyDBContext.Registration_for_a_volunteers.ToList());
                }
                objectMyDBContext.SaveChanges();
            }
            this.Close();
        }
        private bool IsDataCorrcet()
        {
            return textBlockAddEditAddres.Text != string.Empty
                    && textBlockAddEditBirthday.Text != string.Empty
                    && textBlockAddEditMiddleName.Text != string.Empty
                    && textBlockAddEditSurname.Text != string.Empty
                    && textBlockAddEditLastName.Text != string.Empty
                    && textBlockAddEditLogin.Text != string.Empty
                    && textBlockAddEditPassword.Text != string.Empty
                    && textBlockAddEditNumberPhone.Text != string.Empty
                    && textBlockAddEditGenus.Text != string.Empty;
        }
        private WpfApplicationEntity.API.Action_for_the_needy GetActionForTheNeedy(List<WpfApplicationEntity.API.Action_for_the_needy> list)
        {
            foreach (var item in list)
            {
                if (item.Name == this.comboBlockAddEditActionForTheNeedy.SelectedItem.ToString())
                return item;
            }
            return list[0];
        }
        private WpfApplicationEntity.API.Registration_for_a_volunteer GetRegistrationForAVolunteer(List<WpfApplicationEntity.API.Registration_for_a_volunteer> list)
        {
            foreach (var item in list)
            {
                if (item.Date == this.comboBlockAddEditRegistrationForAVolunteer.SelectedItem.ToString())
                    return item;
            }
            return list[0];
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
                {
                    WpfApplicationEntity.API.Volunteer naz = new WpfApplicationEntity.API.Volunteer();
                    List<string> list = new List<string>();
                    var actions = objectMyDBContext.Action_for_the_needys.ToList();
                    foreach (var item in actions)
                    {
                        list.Add(item.Name);
                    }
                    comboBlockAddEditActionForTheNeedy.ItemsSource = list;
                    List<string> list1 = new List<string>();
                    var actions1 = objectMyDBContext.Registration_for_a_volunteers.ToList();
                    foreach (var item in actions1)
                    {
                        list1.Add(item.Date);
                    }
                    comboBlockAddEditRegistrationForAVolunteer.ItemsSource = list1;
                    if (add_edit == false)
                    {
                        ButtonAddEditGroup.Content = "Сохранить";
                        naz = objectMyDBContext.Volunteers.Find(EditID);
                        textBlockAddEditAddres.Text = naz.Addres;
                        textBlockAddEditBirthday.Text = naz.DateOfBirth;
                        textBlockAddEditMiddleName.Text = naz.MiddleName;
                        textBlockAddEditSurname.Text = naz.SurName;
                        textBlockAddEditLastName.Text = naz.LastName;
                        textBlockAddEditLogin.Text = naz.Login;
                        textBlockAddEditPassword.Text = naz.Password;
                        textBlockAddEditNumberPhone.Text = naz.PhoneNumber;
                        textBlockAddEditGenus.Text = naz.Genus;
                        comboBlockAddEditActionForTheNeedy.Text = naz.Action_for_the_needy.Name;
                        comboBlockAddEditRegistrationForAVolunteer.Text = naz.Registration_for_a_volunteer.Date;
                    }
                }
            }
            catch { }
        }
    }
}
