using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    class Service
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SpendingTime { get; set; }
        public virtual Type_Service Type_Service { get; set; }
        public virtual Registration_for_a_needs Registration_for_a_needs { get; set; }
        public virtual Registration_for_a_volunteer Registration_for_a_volunteer { get; set; }
    }
}
