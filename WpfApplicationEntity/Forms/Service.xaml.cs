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
            if (this.add_edit == true)
                if (name.Text != string.Empty
                    && spendingTime.Text != string.Empty)
                {
                    WpfApplicationEntity.API.Service objectService = new WpfApplicationEntity.API.Service();
                    objectService.Name = name.Text;
                    objectService.SpendingTime = spendingTime.Text;
                    try
                    {
                        using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                        {
                            objectMyDBContext.Services.Add(objectService);
                            objectMyDBContext.SaveChanges();
                        }
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
        }
    }
}
