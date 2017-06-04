using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplexModelMVC.Models
{
    public class Manager:Person
    { 
       public string Certificate { get; set; }
    }
} 