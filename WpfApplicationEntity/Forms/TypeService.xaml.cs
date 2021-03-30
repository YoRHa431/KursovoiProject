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
    public partial class TypeServiceWindow : Window
    {
        private bool add_edit;
        public TypeServiceWindow()
        {
            InitializeComponent();
        }
        public TypeServiceWindow(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }
        private void ButtonAddEditTypeService_Click(object sender, RoutedEventArgs e)
        {
            if (this.add_edit == true)
                if (name.Text != string.Empty
                    && discription.Text != string.Empty)
                {
                    WpfApplicationEntity.API.Type_Service objectTypeService = new WpfApplicationEntity.API.Type_Service();
                    objectTypeService.Name = name.Text;
                    objectTypeService.Discripsion = discription.Text;
                    try
                    {
                        using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                        {
                            objectMyDBContext.Type_Services.Add(objectTypeService);
                            objectMyDBContext.SaveChanges();
                        }
                        MessageBox.Show("Тип услуги добавлен");
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
