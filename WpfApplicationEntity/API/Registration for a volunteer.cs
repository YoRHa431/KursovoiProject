using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    class Registration_for_a_volunteer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Date { get; set; }
        public virtual ICollection<Registration_for_a_needs> Registration_for_a_needss { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Volunteer> volunteers { get; set; }
    }
}
