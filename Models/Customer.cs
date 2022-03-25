using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BigFootWebApp.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Interactions = new HashSet<Interaction>();
        }

        public int Id { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [DisplayName("Customer Address")]
        public string CustomerAddress { get; set; }

        public virtual ICollection<Interaction> Interactions { get; set; }
    }
}
