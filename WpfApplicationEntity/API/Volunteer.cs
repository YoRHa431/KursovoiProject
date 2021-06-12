using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    public class Volunteer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Addres { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]  
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Genus { get; set; }
        public virtual Action_for_the_needy Action_for_the_needy { get; set; }
        public virtual Registration_for_a_volunteer Registration_for_a_volunteer { get; set; }
    }
}
