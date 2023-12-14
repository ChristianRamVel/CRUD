using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Address
    {

        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
