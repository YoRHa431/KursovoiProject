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
    public partial class ServiceWindow : Window
    {
        public ServiceWindow(bool add_edit, int ID)
        {
            InitializeComponent();
            this.add_edit = add_edit;
            this.EditID = ID;
        }
        private int ID;
        private int EditID;
        private bool add_edit;
        public ServiceWindow()
        {
            InitializeComponent();
        }
        public ServiceWindow(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }
        private void ButtonAddEditService_Click(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
            {
                if (this.add_edit == true)
                    if (name.Text != string.Empty
                        && spendingTime.Text != string.Empty
                        && comboBlockAddEditRegistrationForAVolunteer.SelectedIndex != -1
                        && comboBlockAddEditRegistrationForANeeds.SelectedIndex != -1
                        && comboBlockAddEditTypeService.SelectedIndex != -1)
                    {
                        WpfApplicationEntity.API.Service objectService = new WpfApplicationEntity.API.Service();
                        objectService.Name = name.Text;
                        objectService.SpendingTime = spendingTime.Text;
                        objectService.Registration_for_a_volunteer = GetRegistrationForAVolunteer(objectMyDBContext.Registration_for_a_volunteers.ToList());
                        objectService.Registration_for_a_needs = GetRegistrationForANeeds(objectMyDBContext.Registration_for_a_needss.ToList());
                        objectService.Type_Service = GetTypeService(objectMyDBContext.Type_Services.ToList());
                        try
                        {
                            objectMyDBContext.Services.Add(objectService);
                            objectMyDBContext.SaveChanges();
                            MessageBox.Show("Услуга добавлена");
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
                    var result = objectMyDBContext.Services.Find(EditID);
                    result.Name = name.Text;
                    result.SpendingTime = spendingTime.Text;
                    result.Registration_for_a_volunteer = GetRegistrationForAVolunteer(objectMyDBContext.Registration_for_a_volunteers.ToList());
                    result.Registration_for_a_needs = GetRegistrationForANeeds(objectMyDBContext.Registration_for_a_needss.ToList());
                    result.Type_Service = GetTypeService(objectMyDBContext.Type_Services.ToList());
                }
                objectMyDBContext.SaveChanges();
            }
            this.Close();
        }
        private bool IsDataCorrcet()
        {
            return name.Text != string.Empty
                    && spendingTime.Text != string.Empty;
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
        private WpfApplicationEntity.API.Registration_for_a_needs GetRegistrationForANeeds(List<WpfApplicationEntity.API.Registration_for_a_needs> list)
        {
            foreach (var item in list)
            {
                if (item.ApplicationDate == this.comboBlockAddEditRegistrationForANeeds.SelectedItem.ToString())
                    return item;
            }
            return list[0];
        }
        private WpfApplicationEntity.API.Type_Service GetTypeService(List<WpfApplicationEntity.API.Type_Service> list)
        {
            foreach (var item in list)
            {
                if (item.Name == this.comboBlockAddEditTypeService.SelectedItem.ToString())
                    return item;
            }
            return list[0];
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
            {
                WpfApplicationEntity.API.Service naz = new WpfApplicationEntity.API.Service();
                List<string> list = new List<string>();
                var actions = objectMyDBContext.Registration_for_a_volunteers.ToList();
                foreach (var item in actions)
                {
                    list.Add(item.Date);
                }
                comboBlockAddEditRegistrationForAVolunteer.ItemsSource = list;
                List<string> list1 = new List<string>();
                var actions1 = objectMyDBContext.Registration_for_a_needss.ToList();
                foreach (var item in actions1)
                {
                    list1.Add(item.ApplicationDate);
                }
                comboBlockAddEditRegistrationForANeeds.ItemsSource = list1;
                List<string> list2 = new List<string>();
                var actions2 = objectMyDBContext.Type_Services.ToList();
                foreach (var item in actions2)
                {
                    list2.Add(item.Name);
                }
                comboBlockAddEditTypeService.ItemsSource = list2;
                if (add_edit == false)
                {
                    ButtonAddEditGroup.Content = "Сохранить";
                    naz = objectMyDBContext.Services.Find(EditID);
                    name.Text = naz.Name;
                    spendingTime.Text = naz.SpendingTime;
                    comboBlockAddEditRegistrationForAVolunteer.Text = naz.Registration_for_a_volunteer.Date;
                    comboBlockAddEditRegistrationForANeeds.Text = naz.Registration_for_a_needs.ApplicationDate;
                    comboBlockAddEditTypeService.Text = naz.Type_Service.Name;
                }
            }
        }
    }
}
