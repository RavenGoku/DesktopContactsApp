using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {
        //Using SQLite with atribute for PirmaryKey and AutoIncrementation
        //The path to the specified system special folder, if that folder physically exists
        //     on your computer; otherwise, an empty string (""). A folder will not physically
        //     exist if the operating system did not create it, the existing folder was deleted,
        //     or the folder is a virtual directory, such as My Computer, which does not correspond
        //     to a physical path.
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // override  ToString() method - is called when object have to be displayed as item of list etc.
        public override string ToString()
        {
            return $"{Name} - {Email} - {PhoneNumber}";
        }
    }
}