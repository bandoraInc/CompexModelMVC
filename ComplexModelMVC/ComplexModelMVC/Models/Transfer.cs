using System;
using System.ComponentModel.DataAnnotations;

namespace ComplexModelMVC.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public Club FromClub { get; set; }
        public Club ToClub { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal Salary { get; set; }

    }
}