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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplicationEntity.API;
using WpfApplicationEntity.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace WpfApplicationEntity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WpfApplicationEntity.API.MyDBContext objectMyDBContext = new WpfApplicationEntity.API.MyDBContext())
                {

                    if (objectMyDBContext.Database.Exists() == false)
                    {
                        objectMyDBContext.Database.Create();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            this.ShowAll();
        }
        private void ShowAll()
        {
            {
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                    new WpfApplicationEntity.API.MyDBContext())
                    {
                       // VolunteerGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetNeedys(objectMyDBContext);
                        needysGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetNeedys(objectMyDBContext);
                        ActionGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetActions(objectMyDBContext);
                        VolunteerGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetVolunteers(objectMyDBContext);
                        serviceGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetServices(objectMyDBContext);
                        typeactionGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetType_Actions(objectMyDBContext);
                        typeServiceGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetType_Services(objectMyDBContext);
                        registrationforavolunteerGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetRegistration_for_a_volunteers(objectMyDBContext);
                        registrationforaneedsGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetRegistration_for_a_needss(objectMyDBContext);
                        actionfortheneedyGrid.ItemsSource = WpfApplicationEntity.API.DatabaseRequest.GetAction_for_the_needys(objectMyDBContext);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void addVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.VolunteerWindow g = new Forms.VolunteerWindow(true,0);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.NeedyWindow g = new Forms.NeedyWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addActionButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.ActionWindow g = new Forms.ActionWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addServiceButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.ServiceWindow g = new Forms.ServiceWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addTypeActionButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.TypeActionWindow g = new Forms.TypeActionWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addTypeServiceButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.TypeServiceWindow g = new Forms.TypeServiceWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addRegistationForAVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.RegistrationForAVolunteerWindow g = new Forms.RegistrationForAVolunteerWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void addRegistationForANeedsButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.RegistrationForANeedsWindow g = new Forms.RegistrationForANeedsWindow(true);
            if (g.ShowDialog() == true)
                this.ShowAll();
        }

        private void editVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            if (VolunteerGrid.SelectedIndex != -1)
            {
                var naz = (Volunteer)VolunteerGrid.SelectedItem;
            Forms.VolunteerWindow g = new Forms.VolunteerWindow(false, naz.ID);
            g.ShowDialog();
            this.ShowAll();
            }
        }

        private void addActionForTheNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.ActionForTheNeedy g = new Forms.ActionForTheNeedy(true);
            g.ShowDialog();
            this.ShowAll();
        }

        private void deleteVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db =new MyDBContext())
            {
                if (VolunteerGrid.SelectedItem != null)
                {
                    var deleted = (Volunteer)VolunteerGrid.SelectedItem;
                    var list = (from item in db.Volunteers.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Volunteers.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }
        private void deleteTypeActionButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (typeactionGrid.SelectedItem != null)
                {
                    var deleted = (Type_Action)typeactionGrid.SelectedItem;
                    var list = (from item in db.Type_Actions.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Type_Actions.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }

        private void deleteTypeServiceButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (typeServiceGrid.SelectedItem != null)
                {
                    var deleted = (Type_Service)typeServiceGrid.SelectedItem;
                    var list = (from item in db.Type_Services.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Type_Services.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }

        private void deleteRegistationForAVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (registrationforavolunteerGrid.SelectedItem != null)
                {
                    var deleted = (Registration_for_a_volunteer)registrationforavolunteerGrid.SelectedItem;
                    var list = (from item in db.Registration_for_a_volunteers.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Registration_for_a_volunteers.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }

        private void deleteRegistationForANeedsButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (registrationforaneedsGrid.SelectedItem != null)
                {
                    var deleted = (Registration_for_a_needs)registrationforaneedsGrid.SelectedItem;
                    var list = (from item in db.Registration_for_a_needss.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Registration_for_a_needss.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }

        private void deleteActionForTheNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (actionfortheneedyGrid.SelectedItem != null)
                {
                    var deleted = (Action_for_the_needy)actionfortheneedyGrid.SelectedItem;
                    var list = (from item in db.Action_for_the_needys.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Action_for_the_needys.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }

        private void deleteActionButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (ActionGrid.SelectedItem != null)
                {
                    var deleted = (WpfApplicationEntity.API.Action)ActionGrid.SelectedItem;
                    var list = (from item in db.Actions.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Actions.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }

        private void deleteNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (needysGrid.SelectedItem != null)
                {
                    var deleted = (Needy)needysGrid.SelectedItem;
                    var list = (from item in db.Needys.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Needys.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }

        private void deleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (serviceGrid.SelectedItem != null)
                {
                    var deleted = (Service)serviceGrid.SelectedItem;
                    var list = (from item in db.Services.ToList()
                                where item.ID.CompareTo(deleted.ID) == 0
                                select item).ToList();
                    db.Services.Remove(list[0]);
                    db.SaveChanges();
                    this.ShowAll();
                }
                else MessageBox.Show("Не выбрано поле для удаления", "Ошибка");
            }
        }

        private void editActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActionGrid.SelectedIndex != -1)
            {
                var naz = (WpfApplicationEntity.API.Action)ActionGrid.SelectedItem;
                Forms.ActionWindow g = new Forms.ActionWindow(false, naz.ID);
                g.ShowDialog();
                this.ShowAll();
            }
        }

        private void editNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            if (needysGrid.SelectedIndex != -1)
            {
                var naz = (WpfApplicationEntity.API.Needy)needysGrid.SelectedItem;
                Forms.NeedyWindow g = new Forms.NeedyWindow(false, naz.ID);
                g.ShowDialog();
                this.ShowAll();
            }
        }

        private void editServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (serviceGrid.SelectedIndex != -1)
            {
                var naz = (WpfApplicationEntity.API.Service)serviceGrid.SelectedItem;
                Forms.ServiceWindow g = new Forms.ServiceWindow(false, naz.ID);
                g.ShowDialog();
                this.ShowAll();
            }
        }

        private void editTypeActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (typeactionGrid.SelectedIndex != -1)
            {
                var naz = (WpfApplicationEntity.API.Type_Action)typeactionGrid.SelectedItem;
                Forms.TypeActionWindow g = new Forms.TypeActionWindow(false, naz.ID);
                g.ShowDialog();
                this.ShowAll();
            }
        }

        private void editTypeServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (typeServiceGrid.SelectedIndex != -1)
            {
                var naz = (WpfApplicationEntity.API.Type_Service)typeServiceGrid.SelectedItem;
                Forms.TypeServiceWindow g = new Forms.TypeServiceWindow(false, naz.ID);
                g.ShowDialog();
                this.ShowAll();
            }
        }

        private void editRegistationForAVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            if (registrationforavolunteerGrid.SelectedIndex != -1)
            {
                var naz = (WpfApplicationEntity.API.Registration_for_a_volunteer)registrationforavolunteerGrid.SelectedItem;
                Forms.RegistrationForAVolunteerWindow g = new Forms.RegistrationForAVolunteerWindow(false, naz.ID);
                g.ShowDialog();
                this.ShowAll();
            }
        }

        private void editRegistationForANeedsButton_Click(object sender, RoutedEventArgs e)
        {
            if (registrationforaneedsGrid.SelectedIndex != -1)
            {
                var naz = (WpfApplicationEntity.API.Registration_for_a_needs)registrationforaneedsGrid.SelectedItem;
                Forms.RegistrationForANeedsWindow g = new Forms.RegistrationForANeedsWindow(false, naz.ID);
                g.ShowDialog();
                this.ShowAll();
            }
        }

        private void editActionForTheNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            if (actionfortheneedyGrid.SelectedIndex != -1)
            {
                var naz = (WpfApplicationEntity.API.Action_for_the_needy)actionfortheneedyGrid.SelectedItem;
                Forms.ActionForTheNeedy g = new Forms.ActionForTheNeedy(false, naz.ID);
                g.ShowDialog();
                this.ShowAll();
            }
        }

        private void ReportEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Excel._Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
            workSheet.Cells[1].EntireRow.Font.Bold = true;
            workSheet.Cells.EntireRow.Font.Size = 14;
            workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
            workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
            workSheet.Cells[1, 1].Interior.ColorIndex = 17;
            workSheet.Cells[1, 1] = "Адрес";
            workSheet.Cells[1, 2].EntireColumn.ColumnWidth = 20;
            workSheet.Cells[1, 2].Interior.ColorIndex = 17;
            workSheet.Cells[1, 2] = "Дата рождения";
            workSheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;
            workSheet.Cells[1, 3].Interior.ColorIndex = 17;
            workSheet.Cells[1, 3] = "Имя";
            workSheet.Cells[1, 4].EntireColumn.ColumnWidth = 25;
            workSheet.Cells[1, 4].Interior.ColorIndex = 17;
            workSheet.Cells[1, 4] = "Фамилия";
            workSheet.Cells[1, 5].EntireColumn.ColumnWidth = 15;
            workSheet.Cells[1, 5].Interior.ColorIndex = 17;
            workSheet.Cells[1, 5] = "Отчество";
            workSheet.Cells[1, 6].EntireColumn.ColumnWidth = 15;
            workSheet.Cells[1, 6].Interior.ColorIndex = 17;
            workSheet.Cells[1, 6] = "Логин";
            workSheet.Cells[1, 7].EntireColumn.ColumnWidth = 20;
            workSheet.Cells[1, 7].Interior.ColorIndex = 17;
            workSheet.Cells[1, 7] = "Пароль";
            workSheet.Cells[1, 8].EntireColumn.ColumnWidth = 20;
            workSheet.Cells[1, 8].Interior.ColorIndex = 17;
            workSheet.Cells[1, 8] = "Номер телефона";
            workSheet.Cells[1, 9].EntireColumn.ColumnWidth = 15;
            workSheet.Cells[1, 9].Interior.ColorIndex = 17;
            workSheet.Cells[1, 9] = "Пол";
            workSheet.Cells[1, 10].EntireColumn.ColumnWidth = 28;
            workSheet.Cells[1, 10].Interior.ColorIndex = 17;
            workSheet.Cells[1, 10] = "Акция для нуждающегося";
            workSheet.Cells[1, 11].EntireColumn.ColumnWidth = 5;
            workSheet.Cells[1, 11].Interior.ColorIndex = 17;
            workSheet.Cells[1, 11] = "Регистрация для волонтёра";
            int i = 2;
            try
            {
                using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                        new WpfApplicationEntity.API.MyDBContext())
                {
                    List<Volunteer> volunteers= DatabaseRequest.GetVolunteers(objectMyDBContext).ToList();
                    foreach (Volunteer volunteer in volunteers)
                    {
                        workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 1] = volunteer.Addres;
                        workSheet.Cells[i, 2].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 2] = volunteer.DateOfBirth;
                        workSheet.Cells[i, 3].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 3] = volunteer.MiddleName;
                        workSheet.Cells[i, 4].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 4] = volunteer.SurName;
                        workSheet.Cells[i, 5].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 5] = volunteer.LastName;
                        workSheet.Cells[i, 6].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 6] = volunteer.Login;
                        workSheet.Cells[i, 7].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 7] = volunteer.Password;
                        workSheet.Cells[i, 8].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 8] = volunteer.PhoneNumber;
                        workSheet.Cells[i, 9].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 9] = volunteer.Genus;
                        workSheet.Cells[i, 10].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 10] = volunteer.Action_for_the_needy.Name;//
                        workSheet.Cells[i, 11].Interior.ColorIndex = 24;
                        workSheet.Cells[i, 11] = volunteer.Registration_for_a_volunteer.Date;//
                        i++;
                    }
                    string pathToXlsFile = Environment.CurrentDirectory +
                        "\\Волонтёры.xls";
                    workSheet.SaveAs(pathToXlsFile);
                    exApp.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReportActionButton_Click(object sender, RoutedEventArgs e)
        {
            {
                Excel._Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                workSheet.Cells[1].EntireRow.Font.Bold = true;
                workSheet.Cells.EntireRow.Font.Size = 14;
                workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
                workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 1].Interior.ColorIndex = 17;
                workSheet.Cells[1, 1] = "Время начала";
                workSheet.Cells[1, 2].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 2].Interior.ColorIndex = 17;
                workSheet.Cells[1, 2] = "Время конца";
                workSheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 3].Interior.ColorIndex = 17;
                workSheet.Cells[1, 3] = "Дата проведения";
                workSheet.Cells[1, 4].EntireColumn.ColumnWidth = 25;
                workSheet.Cells[1, 4].Interior.ColorIndex = 17;
                workSheet.Cells[1, 4] = "Количество волонтёров";
                workSheet.Cells[1, 5].EntireColumn.ColumnWidth = 15;
                workSheet.Cells[1, 5].Interior.ColorIndex = 17;
                workSheet.Cells[1, 5] = "Количество нуждающихся";
                workSheet.Cells[1, 6].EntireColumn.ColumnWidth = 15;
                workSheet.Cells[1, 6].Interior.ColorIndex = 17;
                workSheet.Cells[1, 6] = "Акция для нуждающегося";
                workSheet.Cells[1, 7].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 7].Interior.ColorIndex = 17;
                workSheet.Cells[1, 7] = "Тип акции";
                int i = 2;
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                    {
                        List<WpfApplicationEntity.API.Action> actions = WpfApplicationEntity.API.DatabaseRequest.GetActions(objectMyDBContext).ToList();
                        foreach (WpfApplicationEntity.API.Action action in actions)
                        {
                            workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 1] = action.StarTime;
                            workSheet.Cells[i, 2].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 2] = action.EndTime;
                            workSheet.Cells[i, 3].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 3] = action.TheDateOfThe;
                            workSheet.Cells[i, 4].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 4] = action.NumberOfVolonteers;
                            workSheet.Cells[i, 5].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 5] = action.NumberOfNeeds;                          
                            workSheet.Cells[i, 6].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 6] = action.Action_for_the_needy.Name;
                            workSheet.Cells[i, 7].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 7] = action.Type_Action.Name;
                            i++;
                        }
                        string pathToXlsFile = Environment.CurrentDirectory +
                            "\\Акции.xls";
                        workSheet.SaveAs(pathToXlsFile);
                        exApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void searchVolunteer_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                      new WpfApplicationEntity.API.MyDBContext())
            {
                List<Volunteer> searching = WpfApplicationEntity.API.DatabaseRequest.GetVolunteers(objectMyDBContext).ToList();
                List<Volunteer> volunteers = new List<Volunteer>();
                foreach (var item in searching)
                {
                    if (item.MiddleName.IndexOf(searchVolunteer.Text) != -1)
                        volunteers.Add(item);
                }
                VolunteerGrid.ItemsSource = volunteers;
            }
        }

        private void searchNeedy_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                      new WpfApplicationEntity.API.MyDBContext())
            {
                List<Needy> searching = WpfApplicationEntity.API.DatabaseRequest.GetNeedys(objectMyDBContext).ToList();
                List<Needy> needys = new List<Needy>();
                foreach (var item in searching)
                {
                    if (item.MiddleName.IndexOf(searchNeedy.Text) != -1)
                        needys.Add(item);
                }
                needysGrid.ItemsSource = needys;
            }
        }

        private void ReportServiceButton_Click(object sender, RoutedEventArgs e)
        {
            {
                Excel._Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                workSheet.Cells[1].EntireRow.Font.Bold = true;
                workSheet.Cells.EntireRow.Font.Size = 14;
                workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
                workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 1].Interior.ColorIndex = 17;
                workSheet.Cells[1, 1] = "Название";
                workSheet.Cells[1, 2].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 2].Interior.ColorIndex = 17;
                workSheet.Cells[1, 2] = "Затраченное время";
                workSheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 3].Interior.ColorIndex = 17;
                workSheet.Cells[1, 3] = "Тип услуги";
                workSheet.Cells[1, 4].EntireColumn.ColumnWidth = 25;
                workSheet.Cells[1, 4].Interior.ColorIndex = 17;
                workSheet.Cells[1, 4] = "Регистрация нуждающегося";
                workSheet.Cells[1, 5].EntireColumn.ColumnWidth = 15;
                workSheet.Cells[1, 5].Interior.ColorIndex = 17;
                workSheet.Cells[1, 5] = "Регистрация волонтера";
                int i = 2;
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                    {
                        List<WpfApplicationEntity.API.Service> actions = WpfApplicationEntity.API.DatabaseRequest.GetServices(objectMyDBContext).ToList();
                        foreach (WpfApplicationEntity.API.Service action in actions)
                        {
                            workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 1] = action.Name;
                            workSheet.Cells[i, 2].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 2] = action.SpendingTime;
                            workSheet.Cells[i, 3].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 3] = action.Type_Service.Name;
                            workSheet.Cells[i, 4].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 4] = action.Registration_for_a_needs.ActualDate;
                            workSheet.Cells[i, 5].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 5] = action.Registration_for_a_volunteer.Date;
                            i++;
                        }
                        string pathToXlsFile = Environment.CurrentDirectory +
                            "\\Услуги.xls";
                        workSheet.SaveAs(pathToXlsFile);
                        exApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ReportNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            {
                Excel._Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                workSheet.Cells[1].EntireRow.Font.Bold = true;
                workSheet.Cells.EntireRow.Font.Size = 14;
                workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
                workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 1].Interior.ColorIndex = 17;
                workSheet.Cells[1, 1] = "Фамилия";
                workSheet.Cells[1, 2].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 2].Interior.ColorIndex = 17;
                workSheet.Cells[1, 2] = "Имя";
                workSheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 3].Interior.ColorIndex = 17;
                workSheet.Cells[1, 3] = "Отчество";
                workSheet.Cells[1, 4].EntireColumn.ColumnWidth = 25;
                workSheet.Cells[1, 4].Interior.ColorIndex = 17;
                workSheet.Cells[1, 4] = "Адрес";
                workSheet.Cells[1, 5].EntireColumn.ColumnWidth = 15;
                workSheet.Cells[1, 5].Interior.ColorIndex = 17;
                workSheet.Cells[1, 5] = "Инвалидность";
                workSheet.Cells[1, 6].EntireColumn.ColumnWidth = 15;
                workSheet.Cells[1, 6].Interior.ColorIndex = 17;
                workSheet.Cells[1, 6] = "Номер телефона";
                workSheet.Cells[1, 7].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 7].Interior.ColorIndex = 17;
                workSheet.Cells[1, 7] = "Пол";
                workSheet.Cells[1, 8].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 8].Interior.ColorIndex = 17;
                workSheet.Cells[1, 8] = "Регистрация нуждающегося";
                workSheet.Cells[1, 9].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 9].Interior.ColorIndex = 17;
                workSheet.Cells[1, 9] = "Акция нуждающегося";
                int i = 2;
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                    {
                        List<WpfApplicationEntity.API.Needy> actions = WpfApplicationEntity.API.DatabaseRequest.GetNeedys(objectMyDBContext).ToList();
                        foreach (WpfApplicationEntity.API.Needy action in actions)
                        {
                            workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 1] = action.MiddleName;
                            workSheet.Cells[i, 2].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 2] = action.SurName;
                            workSheet.Cells[i, 3].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 3] = action.LastName;
                            workSheet.Cells[i, 4].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 4] = action.Addres;
                            workSheet.Cells[i, 5].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 5] = action.Disability;
                            workSheet.Cells[i, 6].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 6] = action.PhoneNumber;
                            workSheet.Cells[i, 7].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 7] = action.Genus;
                            workSheet.Cells[i, 8].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 8] = action.Registration_for_a_needs.ActualDate;
                            workSheet.Cells[i, 9].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 9] = action.Action_for_the_needy.Name;
                            i++;
                        }
                        string pathToXlsFile = Environment.CurrentDirectory +
                            "\\Нуждающиеся.xls";
                        workSheet.SaveAs(pathToXlsFile);
                        exApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ReportTypeActionButton_Click(object sender, RoutedEventArgs e)
        {
            {
                Excel._Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                workSheet.Cells[1].EntireRow.Font.Bold = true;
                workSheet.Cells.EntireRow.Font.Size = 14;
                workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
                workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 1].Interior.ColorIndex = 17;
                workSheet.Cells[1, 1] = "Название";
                workSheet.Cells[1, 2].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 2].Interior.ColorIndex = 17;
                workSheet.Cells[1, 2] = "Описание";
                workSheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 3].Interior.ColorIndex = 17;
                workSheet.Cells[1, 3] = "Длительность";
                int i = 2;
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                    {
                        List<WpfApplicationEntity.API.Type_Action> actions = WpfApplicationEntity.API.DatabaseRequest.GetType_Actions(objectMyDBContext).ToList();
                        foreach (WpfApplicationEntity.API.Type_Action action in actions)
                        {
                            workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 1] = action.Name;
                            workSheet.Cells[i, 2].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 2] = action.Discription;
                            workSheet.Cells[i, 3].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 3] = action.Duration;
                            i++;
                        }
                        string pathToXlsFile = Environment.CurrentDirectory +
                            "\\Типы_акций.xls";
                        workSheet.SaveAs(pathToXlsFile);
                        exApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ReportTypeServiceButton_Click(object sender, RoutedEventArgs e)
        {
            {
                Excel._Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                workSheet.Cells[1].EntireRow.Font.Bold = true;
                workSheet.Cells.EntireRow.Font.Size = 14;
                workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
                workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 1].Interior.ColorIndex = 17;
                workSheet.Cells[1, 1] = "Название";
                workSheet.Cells[1, 2].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 2].Interior.ColorIndex = 17;
                workSheet.Cells[1, 2] = "Описание";
                int i = 2;
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                    {
                        List<WpfApplicationEntity.API.Type_Service> actions = WpfApplicationEntity.API.DatabaseRequest.GetType_Services(objectMyDBContext).ToList();
                        foreach (WpfApplicationEntity.API.Type_Service action in actions)
                        {
                            workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 1] = action.Name;
                            workSheet.Cells[i, 2].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 2] = action.Discripsion;
                            i++;
                        }
                        string pathToXlsFile = Environment.CurrentDirectory +
                            "\\Типы_услуг.xls";
                        workSheet.SaveAs(pathToXlsFile);
                        exApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ReportRegistrationForAVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            {
                Excel._Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                workSheet.Cells[1].EntireRow.Font.Bold = true;
                workSheet.Cells.EntireRow.Font.Size = 14;
                workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
                workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 1].Interior.ColorIndex = 17;
                workSheet.Cells[1, 1] = "Дата";
                int i = 2;
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                    {
                        List<WpfApplicationEntity.API.Registration_for_a_volunteer> actions = WpfApplicationEntity.API.DatabaseRequest.GetRegistration_for_a_volunteers(objectMyDBContext).ToList();
                        foreach (WpfApplicationEntity.API.Registration_for_a_volunteer action in actions)
                        {
                            workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 1] = action.Date;
                            i++;
                        }
                        string pathToXlsFile = Environment.CurrentDirectory +
                            "\\Регистрации_волонтеров.xls";
                        workSheet.SaveAs(pathToXlsFile);
                        exApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ReportActionForTheNeedyButton_Click(object sender, RoutedEventArgs e)
        {
            {
                Excel._Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                workSheet.Cells[1].EntireRow.Font.Bold = true;
                workSheet.Cells.EntireRow.Font.Size = 14;
                workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
                workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 1].Interior.ColorIndex = 17;
                workSheet.Cells[1, 1] = "Название";
                int i = 2;
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                    {
                        List<WpfApplicationEntity.API.Action_for_the_needy> actions = WpfApplicationEntity.API.DatabaseRequest.GetAction_for_the_needys(objectMyDBContext).ToList();
                        foreach (WpfApplicationEntity.API.Action_for_the_needy action in actions)
                        {
                            workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 1] = action.Name;
                            i++;
                        }
                        string pathToXlsFile = Environment.CurrentDirectory +
                            "\\Акции_нуждающихся.xls";
                        workSheet.SaveAs(pathToXlsFile);
                        exApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ReportRegistrationForANeedsButton_Click(object sender, RoutedEventArgs e)
        {
            {
                Excel._Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                workSheet.Cells[1].EntireRow.Font.Bold = true;
                workSheet.Cells.EntireRow.Font.Size = 14;
                workSheet.Cells.EntireRow.Font.Name = "TimesNewRoman";
                workSheet.Cells[1, 1].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 1].Interior.ColorIndex = 17;
                workSheet.Cells[1, 1] = "Планируемая дата";
                workSheet.Cells[1, 2].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 2].Interior.ColorIndex = 17;
                workSheet.Cells[1, 2] = "Дата подачи";
                workSheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;
                workSheet.Cells[1, 3].Interior.ColorIndex = 17;
                workSheet.Cells[1, 3] = "Фактическая дата";
                workSheet.Cells[1, 4].EntireColumn.ColumnWidth = 25;
                workSheet.Cells[1, 4].Interior.ColorIndex = 17;
                workSheet.Cells[1, 4] = "Запись волонтера";
                int i = 2;
                try
                {
                    using (WpfApplicationEntity.API.MyDBContext objectMyDBContext =
                            new WpfApplicationEntity.API.MyDBContext())
                    {
                        List<WpfApplicationEntity.API.Registration_for_a_needs> actions = WpfApplicationEntity.API.DatabaseRequest.GetRegistration_for_a_needss(objectMyDBContext).ToList();
                        foreach (WpfApplicationEntity.API.Registration_for_a_needs action in actions)
                        {
                            workSheet.Cells[i, 1].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 1] = action.PlannedDate;
                            workSheet.Cells[i, 2].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 2] = action.ApplicationDate;
                            workSheet.Cells[i, 3].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 3] = action.ActualDate;
                            workSheet.Cells[i, 4].Interior.ColorIndex = 24;
                            workSheet.Cells[i, 4] = action.Registration_for_a_volunteer.Date;
                            i++;
                        }
                        string pathToXlsFile = Environment.CurrentDirectory +
                            "\\Регистрация_нуждающегося.xls";
                        workSheet.SaveAs(pathToXlsFile);
                        exApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
