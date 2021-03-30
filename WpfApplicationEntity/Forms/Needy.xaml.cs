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
            if (this.add_edit == true)
                if (Addres.Text != string.Empty
                    && MiddleName.Text != string.Empty
                    && Surname.Text != string.Empty
                    && LastName.Text != string.Empty
                    && Disability.Text != string.Empty
                    && PhoneNumber.Text != string.Empty
                    && Genum.Text != string.Empty)
                {
                    WpfApplicationEntity.API.Needy objectNeedy = new WpfApplicationEntity.API.Needy();
                    objectNeedy.Addres = Addres.Text;
                    objectNeedy.MiddleName = MiddleName.Text;
                    objectNeedy.SurName = Surname.Text;
                    objectNeedy.LastName = LastName.Text;
                    objectNeedy.Disability = Disability.Text;
                    objectNeedy.PhoneNumber = PhoneNumber.Text;
                    objectNeedy.Genus = Genum.Text;
                    try
                    {
                        using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                        {
                            objectMyDBContext.Needys.Add(objectNeedy);
                            objectMyDBContext.SaveChanges();
                        }
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
        }
    }
}
