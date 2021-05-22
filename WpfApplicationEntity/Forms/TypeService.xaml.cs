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
        public TypeServiceWindow(bool add_edit, int ID)
        {
            InitializeComponent();
            this.add_edit = add_edit;
            this.EditID = ID;
        }
        private int ID;
        private int EditID;
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
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
            {
                if (this.add_edit == true)
                    if (name.Text != string.Empty
                        && discripsion.Text != string.Empty)
                    {
                        WpfApplicationEntity.API.Type_Service objectTypeService = new WpfApplicationEntity.API.Type_Service();
                        objectTypeService.Name = name.Text;
                        objectTypeService.Discripsion = discripsion.Text;
                        try
                        {
                            objectMyDBContext.Type_Services.Add(objectTypeService);
                            objectMyDBContext.SaveChanges();
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
                else
                {
                    var result = objectMyDBContext.Type_Services.Find(EditID);
                    result.Name = name.Text;
                    result.Discripsion = discripsion.Text;
                }
                objectMyDBContext.SaveChanges();
            }
            this.Close();
        }
        private bool IsDataCorrcet()
        {
            return name.Text != string.Empty
                    && discripsion.Text != string.Empty;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
            {
                WpfApplicationEntity.API.Type_Service naz = new WpfApplicationEntity.API.Type_Service();
                if (add_edit == false)
                {
                    ButtonAddEditGroup.Content = "Сохранить";
                    naz = objectMyDBContext.Type_Services.Find(EditID);
                    name.Text = naz.Name;
                    discripsion.Text = naz.Discripsion;
                }
            }
        }
    }
}
