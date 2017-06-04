using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComplexModelMVC.Models
{
    public class Player : Person
    {
       
        public Position Position { get; set; }
        public virtual Club Club { get; set; }
    }
}