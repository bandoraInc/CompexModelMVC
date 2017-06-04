using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplexModelMVC.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string FlagURL { get; set; }
        public virtual Federation Federation { get; set; }

        public virtual List<Club> Clubs { get; set; }
    }
}