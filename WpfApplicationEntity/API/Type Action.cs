using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    public class Type_Action
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Discription { get; set; }
        [Required]
        public string Duration { get; set; }
        public virtual ICollection<Action> Action { get; set; }
    }
}
