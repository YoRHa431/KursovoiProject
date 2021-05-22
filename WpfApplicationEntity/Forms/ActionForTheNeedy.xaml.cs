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
    /// Логика взаимодействия для ActionForTheNeedy.xaml
    /// </summary>
    public partial class ActionForTheNeedy : Window
    {
        public ActionForTheNeedy(bool add_edit, int ID)
        {
            InitializeComponent();
            this.add_edit = add_edit;
            this.EditID = ID;
        }
        private int ID;
        private int EditID;
        public ActionForTheNeedy()
        {
            InitializeComponent();
        }
        public ActionForTheNeedy(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }
        private bool add_edit;
        private void ButtonAddEditAction_Click(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
            {
                if (this.add_edit == true)
                    if (Name.Text != string.Empty)
                    {
                        WpfApplicationEntity.API.Action_for_the_needy objectAction = new WpfApplicationEntity.API.Action_for_the_needy();
                        objectAction.Name = Name.Text;
                        try
                        {
                            objectMyDBContext.Action_for_the_needys.Add(objectAction);
                            objectMyDBContext.SaveChanges();
                            MessageBox.Show("Акция для нуждающегося добавлена");
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
                    var result = objectMyDBContext.Action_for_the_needys.Find(EditID);
                    result.Name = Name.Text;
                }
                objectMyDBContext.SaveChanges();
            }
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
            {
                WpfApplicationEntity.API.Action_for_the_needy naz = new WpfApplicationEntity.API.Action_for_the_needy();
                if (add_edit == false)
                {
                    ButtonAddEditGroup.Content = "Сохранить";
                    naz = objectMyDBContext.Action_for_the_needys.Find(EditID);
                    Name.Text = naz.Name;
                }
            }
        }
    }
}
