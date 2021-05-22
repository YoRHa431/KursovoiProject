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
using WpfApplicationEntity.API;
namespace WpfApplicationEntity.Forms
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void ButtonAddEditAutorization_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db =new MyDBContext())
            {
                if (!String.IsNullOrWhiteSpace(login.Text) && !String.IsNullOrWhiteSpace(password.Text))
                {
                    var users = (from user in db.Volunteers.ToList()
                                 where user.Login.CompareTo(login.Text) == 0 && user.Password.CompareTo(password.Text) == 0
                                 select user).ToList();
                    if (users.Count > 0 && db.Volunteers.Count() > 0)
                    {
                        MainWindow f = new MainWindow();
                        f.ShowDialog();
                    }
                    else MessageBox.Show("Пользователь с такими данными не найден", "Ошибка");
                }
                else MessageBox.Show("Не заполненны поля");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db=new MyDBContext())
            if(db.Database.Exists()==false)
            {
                db.Database.Create();
                WpfApplicationEntity.API.Volunteer objectVolunteer = new WpfApplicationEntity.API.Volunteer();
                objectVolunteer.Addres = "Creators";
                objectVolunteer.DateOfBirth = "Creators";
                objectVolunteer.MiddleName = "Creators";
                objectVolunteer.SurName = "Creators";
                objectVolunteer.LastName = "Creators";
                objectVolunteer.Login = "999";
                objectVolunteer.Password = "666";
                objectVolunteer.PhoneNumber = "Creators";
                objectVolunteer.Genus = "Creators";
                objectVolunteer.Registration_for_a_volunteer = new Registration_for_a_volunteer { ID=0,Date="[eq"};
                objectVolunteer.Action_for_the_needy = new Action_for_the_needy { Name = "qeddv", ID=0};
                db.Volunteers.Add(objectVolunteer);
                db.SaveChanges();
            }
        }
    }
}
