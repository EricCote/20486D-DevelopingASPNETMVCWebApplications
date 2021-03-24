using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EntityFrameworkExample.Models
{
    [MetadataType(typeof(PersonneMeta))]
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}
