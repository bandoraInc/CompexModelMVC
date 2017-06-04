using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplexModelMVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Photo { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Transfer> Transfers { get; set; }

    }
}