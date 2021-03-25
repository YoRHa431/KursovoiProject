using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WpfApplicationEntity.API
{
    class Action
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string EntStart { get; set; }
        [Required]
        public string TheDateOfThe { get; set; }
        [Required]
        public int NumberOfVolonteers { get; set; }
        [Required]
        public int NumberOfNeeds { get; set; }
        [Required]
        public virtual ICollection<Type_Action> Type_Actions { get; set; }
    }
}
