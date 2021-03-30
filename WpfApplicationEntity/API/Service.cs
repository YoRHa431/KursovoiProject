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
        [Required]
        public virtual ICollection<Type_Service> Type_Services { get; set; }
    }
}
