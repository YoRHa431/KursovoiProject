using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    class Action_for_the_needy
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Volunteer> Volonteers { get; set; }
        public virtual ICollection<Needy> Needys { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
    }
}
