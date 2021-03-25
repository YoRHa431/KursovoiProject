using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    class Needy
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Addres { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Disability { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Genus { get; set; }
    }
}
