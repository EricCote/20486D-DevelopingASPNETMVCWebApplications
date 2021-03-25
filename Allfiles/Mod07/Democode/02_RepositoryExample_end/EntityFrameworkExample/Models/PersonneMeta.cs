using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

//   using System.ComponentModel.DataAnnotations;
//    [MetadataType(typeof(PersonneMeta))]



namespace EntityFrameworkExample.Models
{
    public class PersonneMeta
    {
        public int PersonId { get; set; }

        [Display(Name ="Prénom")]
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
