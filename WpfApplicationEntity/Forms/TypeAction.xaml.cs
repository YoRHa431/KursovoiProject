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
    public partial class TypeActionWindow : Window
    {
        private bool add_edit;
        public TypeActionWindow()
        {
            InitializeComponent();
        }
        public TypeActionWindow(bool add_edit)
        {
            InitializeComponent();
            this.add_edit = add_edit;
        }
        private void ButtonAddEditTypeAction_Click(object sender, RoutedEventArgs e)
        {
            if (this.add_edit == true)
                if (name.Text != string.Empty
                    && discription.Text != string.Empty
                    && duration.Text != string.Empty)
                {
                    WpfApplicationEntity.API.Type_Action objectTypeAction = new WpfApplicationEntity.API.Type_Action();
                    objectTypeAction.Name = name.Text;
                    objectTypeAction.Discripsion = discription.Text;
                    objectTypeAction.Duration = duration.Text;
                    try
                    {
                        using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                        {
                            objectMyDBContext.Type_Actions.Add(objectTypeAction);
                            objectMyDBContext.SaveChanges();
                        }
                        MessageBox.Show("Тип акции добавлен");
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
