using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    class DataBaseRequest
    {
        public struct NewVolunteer
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
            public NewVolunteer(int ID, string Addres, string DateOfBirth, string MiddleName, string SurName, string LastName, string Login, string Password, string PhoneNumber, string Genus)
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
    }
}
