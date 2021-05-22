using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    class DatabaseRequest
    {
        public class NewVolunteer
        {
            public int ID { get; set; }
            public string Addres { get; set; }
            public string DateOfBirth { get; set; }
            public string MiddleName { get; set; }
            public string SurName { get; set; }
            public string LastName { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string PhoneNumber { get; set; }
            public string Genus { get; set; }
            /// <summary>
            /// Волонтёр
            /// </summary>
            /// <param name="Id">id волонтёра</param>
            /// <param name="Addres">адрес волонтёра</param>
            /// <param name="DateOfBirth">дата рождения волонтёра</param>
            /// <param name="MiddleName">отчество волонтёра</param>
            /// <param name="SurName">имя волонтёра</param>
            /// <param name="LastName">отчество волонтёра</param>
            /// <param name="Login">логин</param>
            /// <param name="Password">пароль</param>
            /// <param name="PhoneNumber">номер мобильного телефона волонтёра</param>
            /// <param name="Genus">пол волонтёра</param>
            /// 
            public NewVolunteer(int ID, string Addres, string DateOfBirth, string MiddleName, string SurName, string LastName,
                 string Login, string Password, string PhoneNumber, string Genus)
            {
                this.ID = ID;
                this.Addres = Addres;
                this.DateOfBirth = DateOfBirth;
                this.MiddleName = MiddleName;
                this.SurName = SurName;
                this.LastName = LastName;
                this.Login = Login;
                this.Password = Password;
                this.PhoneNumber = PhoneNumber;
                this.Genus = Genus;
            }
        }
        #region Database
        static DatabaseRequest()
        {
        }
        public static bool IsUser(MyDBContext objectMyDBContext, string login, string password)
        {
            var tmp = (
                from tmpUser in objectMyDBContext.Volunteers.ToList<Volunteer>()
                where tmpUser.Login.CompareTo(login) == 0 && tmpUser.Password.CompareTo(password) == 0
                select tmpUser
                      ).ToList();
            if (tmp.Count == 1)
                return true;
            return false;
        }
         #endregion
        #region Needy
        public static IEnumerable<Needy> GetNeedys(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Needys.ToList();
        }
        public static Needy GetNeedyID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Needys.ToList<Needy>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
        #region Action
        public static IEnumerable<Action> GetActions(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Actions.ToList();
        }
        public static Action GetActionID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Actions.ToList<Action>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
        #region Volunteer
        public static IEnumerable<Volunteer> GetVolunteers(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Volunteers.ToList();
        }
        public static Volunteer GetVolunteerID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Volunteers.ToList<Volunteer>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
        #region Service
        public static IEnumerable<Service> GetServices(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Services.ToList();
        }
        public static IEnumerable<Action_for_the_needy> GetActionsForTheNeedy(MyDBContext objectMYDBContext)
        {
            return objectMYDBContext.Action_for_the_needys.ToList();
        }
        public static Service GetServiceID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Services.ToList<Service>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
        #region Action for the needy
        public static IEnumerable<Action_for_the_needy> GetAction_for_the_needys(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Action_for_the_needys.ToList();
        }
        public static Action_for_the_needy GetAction_for_the_needyID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Action_for_the_needys.ToList<Action_for_the_needy>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
        #region Registration for a volunteer
        public static IEnumerable<Registration_for_a_volunteer> GetRegistration_for_a_volunteers(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Registration_for_a_volunteers.ToList();
        }
        public static Registration_for_a_volunteer GetRegistration_for_a_volunteerID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Registration_for_a_volunteers.ToList<Registration_for_a_volunteer>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
        #region Registration for a needs
        public static IEnumerable<Registration_for_a_needs> GetRegistration_for_a_needss(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Registration_for_a_needss.ToList();
        }
        public static Registration_for_a_needs GetRegistration_for_a_needsID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Registration_for_a_needss.ToList<Registration_for_a_needs>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
        #region Type action
        public static IEnumerable<Type_Action> GetType_Actions(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Type_Actions.ToList();
        }
        public static Type_Action GetType_ActionID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Type_Actions.ToList<Type_Action>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
        #region Type Service
        public static IEnumerable<Type_Service> GetType_Services(MyDBContext objectMyDBContext)
        {
            return objectMyDBContext.Type_Services.ToList();
        }
        public static Type_Service GetType_ServiceID(MyDBContext objectMyDBContext, int ID)
        {
            return (from tempGroup in objectMyDBContext.Type_Services.ToList<Type_Service>()
                    where tempGroup.ID == ID
                    select tempGroup).SingleOrDefault();
        }
        #endregion
    }
}