using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    class Registration_for_a_needs
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string PlannedDate { get; set; }
        [Required]
        public string ApplicationDate { get; set; }
        [Required]
        public string ActualDate { get; set; }
        [Required]
        public virtual ICollection<Needy> Needys { get; set; }
        [Required]
        public virtual ICollection<Service> Services { get; set; }
    }
}
