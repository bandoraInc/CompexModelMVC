using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplexModelMVC.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country{get;set;}
        public string Slogan { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual Manager Manager { get; set; }
    }
}