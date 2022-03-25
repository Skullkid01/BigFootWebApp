using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BigFootWebApp.Models
{
    public partial class Interaction
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Date On")]
        public DateTime DateOn { get; set; }

        [Required]
        [DisplayName("Interaction Detail")]
        public string InteractionDetail { get; set; }

        [DisplayName("Deal Value")]
        public decimal? DealValue { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
