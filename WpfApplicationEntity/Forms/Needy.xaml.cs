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
    public partial class NeedyWindow : Window
    {
        public NeedyWindow(bool add_edit, int ID)
        {
            InitializeComponent();
            this.add_edit = add_edit;
            this.EditID = ID;
        }
        private int ID;
        private int EditID;
        private bool add_edit;
        public NeedyWindow()
        {
            InitializeComponent();
        }
        public NeedyWindow(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }

        private void ButtonAddEditNeedy_Click(object sender, RoutedEventArgs e)
        {
         using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
         {
            if (this.add_edit == true)
                if (Addres.Text != string.Empty
                    && MiddleName.Text != string.Empty
                    && Surname.Text != string.Empty
                    && LastName.Text != string.Empty
                    && Disability.Text != string.Empty
                    && PhoneNumber.Text != string.Empty
                    && Genum.Text != string.Empty
                    && comboBlockAddEditRegistrationForANeeds.SelectedIndex != -1
                    && comboBlockAddEditActionForTheNeedy.SelectedIndex != -1)
                {
                    WpfApplicationEntity.API.Needy objectNeedy = new WpfApplicationEntity.API.Needy();
                    objectNeedy.Addres = Addres.Text;
                    objectNeedy.MiddleName = MiddleName.Text;
                    objectNeedy.SurName = Surname.Text;
                    objectNeedy.LastName = LastName.Text;
                    objectNeedy.Disability = Disability.Text;
                    objectNeedy.PhoneNumber = PhoneNumber.Text;
                    objectNeedy.Genus = Genum.Text;
                    objectNeedy.Registration_for_a_needs = GetRegistrationForANeeds(objectMyDBContext.Registration_for_a_needss.ToList());
                    objectNeedy.Action_for_the_needy = GetActionForTheNeedy(objectMyDBContext.Action_for_the_needys.ToList());
                    try
                    {
                        objectMyDBContext.Needys.Add(objectNeedy);
                        objectMyDBContext.SaveChanges();
                        MessageBox.Show("Нуждающийся добавлен");
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
                var result = objectMyDBContext.Needys.Find(EditID);
                result.Addres = Addres.Text;
                result.MiddleName = MiddleName.Text;
                result.SurName = Surname.Text;
                result.LastName = LastName.Text;
                result.Disability = Disability.Text;
                result.PhoneNumber = PhoneNumber.Text;
                result.Genus = Genum.Text;
                result.Registration_for_a_needs = GetRegistrationForANeeds(objectMyDBContext.Registration_for_a_needss.ToList());
                result.Action_for_the_needy = GetActionForTheNeedy(objectMyDBContext.Action_for_the_needys.ToList());
            }
            objectMyDBContext.SaveChanges();
        }
        this.Close();
    }
        private bool IsDataCorrcet()
        {
            return Addres.Text != string.Empty
                    && MiddleName.Text != string.Empty
                    && Surname.Text != string.Empty
                    && LastName.Text != string.Empty
                    && Disability.Text != string.Empty
                    && PhoneNumber.Text != string.Empty
                    && Genum.Text != string.Empty;
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
        private WpfApplicationEntity.API.Action_for_the_needy GetActionForTheNeedy(List<WpfApplicationEntity.API.Action_for_the_needy> list)
        {
            foreach (var item in list)
            {
                if (item.Name == this.comboBlockAddEditActionForTheNeedy.SelectedItem.ToString())
                    return item;
            }
            return list[0];
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
            {
                WpfApplicationEntity.API.Needy naz = new WpfApplicationEntity.API.Needy();
                List<string> list = new List<string>();
                var actions = objectMyDBContext.Registration_for_a_needss.ToList();
                foreach (var item in actions)
                {
                    list.Add(item.ApplicationDate);
                }
                comboBlockAddEditRegistrationForANeeds.ItemsSource = list;
                List<string> list1 = new List<string>();
                var actions1 = objectMyDBContext.Action_for_the_needys.ToList();
                foreach (var item in actions1)
                {
                    list1.Add(item.Name);
                }
                comboBlockAddEditActionForTheNeedy.ItemsSource = list1;
                if (add_edit == false)
                {
                    ButtonAddEditNeedy.Content = "Сохранить";
                    naz = objectMyDBContext.Needys.Find(EditID);
                    Addres.Text = naz.Addres;
                    MiddleName.Text = naz.MiddleName;
                    Surname.Text = naz.SurName;
                    LastName.Text = naz.LastName;
                    Disability.Text = naz.Disability;
                    PhoneNumber.Text = naz.PhoneNumber;
                    Genum.Text = naz.Genus;
                    comboBlockAddEditRegistrationForANeeds.Text = naz.Registration_for_a_needs.ApplicationDate;
                    comboBlockAddEditActionForTheNeedy.Text = naz.Action_for_the_needy.Name;
                }
            }
        }
    }
}
