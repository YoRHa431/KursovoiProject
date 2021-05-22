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
    public partial class ActionWindow : Window
    {
        public ActionWindow(bool add_edit, int ID)
        {
            InitializeComponent();
            this.add_edit = add_edit;
            this.EditID = ID;
        }
        private int ID;
        private int EditID;
        private bool add_edit;
        public ActionWindow()
        {
            InitializeComponent();
        }
        public ActionWindow(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }
        private void ButtonAddEditAction_Click(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
            {
                if (this.add_edit == true)
                    if (Starttime.Text != string.Empty
                        && Endtime.Text != string.Empty
                        && Dateofthe.Text != string.Empty
                        && Numberofvolunteer.Text != string.Empty
                        && Numberofneedy.Text != string.Empty
                        && comboBlockAddEditActionForTheNeedy.SelectedIndex != -1
                        && comboBlockAddEditTypeAction.SelectedIndex != -1)
                    {
                        WpfApplicationEntity.API.Action objectAction = new WpfApplicationEntity.API.Action();
                        objectAction.StarTime = Starttime.Text;
                        objectAction.EndTime = Endtime.Text;
                        objectAction.TheDateOfThe = Dateofthe.Text;
                        objectAction.NumberOfVolonteers = Convert.ToInt32(Numberofvolunteer.Text);
                        objectAction.NumberOfNeeds = Convert.ToInt32(Numberofneedy.Text);
                        objectAction.Action_for_the_needy = GetActionForTheNeedy(objectMyDBContext.Action_for_the_needys.ToList());
                        objectAction.Type_Action = GetTypeAction(objectMyDBContext.Type_Actions.ToList());
                        try
                        {
                            objectMyDBContext.Actions.Add(objectAction);
                            objectMyDBContext.SaveChanges();
                            MessageBox.Show("Акция добавлена");
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
                    var result = objectMyDBContext.Actions.Find(EditID);
                    result.StarTime = Starttime.Text;
                    result.EndTime = Endtime.Text;
                    result.TheDateOfThe = Dateofthe.Text;
                    result.NumberOfVolonteers = Convert.ToInt32(Numberofvolunteer.Text);
                    result.NumberOfNeeds = Convert.ToInt32(Numberofneedy.Text);
                    result.Action_for_the_needy = GetActionForTheNeedy(objectMyDBContext.Action_for_the_needys.ToList());
                    result.Type_Action = GetTypeAction(objectMyDBContext.Type_Actions.ToList());
                }
                objectMyDBContext.SaveChanges();
            }
            this.Close();
        }
         private bool IsDataCorrcet()
        {
            return Starttime.Text != string.Empty
                   && Endtime.Text != string.Empty
                   && Dateofthe.Text != string.Empty
                   && Numberofvolunteer.Text != string.Empty
                   && Numberofneedy.Text != string.Empty;
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
         private WpfApplicationEntity.API.Type_Action GetTypeAction(List<WpfApplicationEntity.API.Type_Action> list)
         {
             foreach (var item in list)
             {
                 if (item.Name == this.comboBlockAddEditTypeAction.SelectedItem.ToString())
                     return item;
             }
             return list[0];
         }
         private void Window_Loaded(object sender, RoutedEventArgs e)
         {
             using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
             {
                 WpfApplicationEntity.API.Action naz = new WpfApplicationEntity.API.Action();
                 List<string> list = new List<string>();
                 var actions = objectMyDBContext.Action_for_the_needys.ToList();
                 foreach (var item in actions)
                 {
                     list.Add(item.Name);
                 }
                 comboBlockAddEditActionForTheNeedy.ItemsSource = list;
                 List<string> list1 = new List<string>();
                 var actions1 = objectMyDBContext.Type_Actions.ToList();
                 foreach (var item in actions1)
                 {
                     list1.Add(item.Name);
                 }
                 comboBlockAddEditTypeAction.ItemsSource = list1;
                 if(add_edit==false)
                 {
                     ButtonAddEditGroup.Content = "Сохранить";
                     naz = objectMyDBContext.Actions.Find(EditID);
                     Starttime.Text = naz.StarTime;
                     Endtime.Text = naz.EndTime;
                     Dateofthe.Text = naz.TheDateOfThe;
                     Numberofvolunteer.Text = naz.NumberOfVolonteers.ToString();
                     Numberofneedy.Text = naz.NumberOfNeeds.ToString();
                     comboBlockAddEditActionForTheNeedy.Text = naz.Action_for_the_needy.Name;
                     comboBlockAddEditTypeAction.Text = naz.Type_Action.Name;
                 }
             }
         }
    }
}
