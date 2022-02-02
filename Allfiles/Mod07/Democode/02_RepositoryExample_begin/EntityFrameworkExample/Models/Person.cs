using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkExample.Models;

    public class Person
    {
        public int PersonId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
    }
