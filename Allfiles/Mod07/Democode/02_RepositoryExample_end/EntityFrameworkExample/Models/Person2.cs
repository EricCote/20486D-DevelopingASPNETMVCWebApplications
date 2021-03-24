using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkExample.Models
{
    [Display(Name = "Personne")]
    public partial class Person
    {
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
    }
}
