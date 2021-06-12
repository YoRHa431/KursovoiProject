using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    public class Registration_for_a_needs
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string PlannedDate { get; set; }
        [Required]
        public string ApplicationDate { get; set; }
        [Required]
        public string ActualDate { get; set; }
        public virtual ICollection<Needy> Needys { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual Registration_for_a_volunteer Registration_for_a_volunteer { get; set; }
    }
}
