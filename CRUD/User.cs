using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    //[Index(nameof(Name), IsUnique = true)] // Para que el nombre sea un campo único
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Address> Address { get; private set; } = new ObservableCollection<Address>();

    }
}
