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
            if (this.add_edit == true)
                if (Starttime.Text != string.Empty
                    && Endtime.Text != string.Empty
                    && Dateofthe.Text != string.Empty
                    && Numberofvolunteer.Text != string.Empty
                    && Numberofneedy.Text != string.Empty)
                {
                    WpfApplicationEntity.API.Action objectAction = new WpfApplicationEntity.API.Action();
                    objectAction.StarTime = Starttime.Text;
                    objectAction.EndTime = Endtime.Text;
                    objectAction.TheDateOfThe = Dateofthe.Text;
                    objectAction.NumberOfVolonteers = Convert.ToInt32(Numberofvolunteer.Text);
                    objectAction.NumberOfNeeds = Convert.ToInt32(Numberofneedy.Text);
                    try
                    {
                        using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                        {
                            objectMyDBContext.Actions.Add(objectAction);
                            objectMyDBContext.SaveChanges();
                        }
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
        }
    }
}
