using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplexModelMVC.Models
{
    public class Federation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string Slogan { get; set; }
        public virtual Federation BelongsTo { get; set; }

        public virtual List<Country> Countries { get; set; }

    }
}