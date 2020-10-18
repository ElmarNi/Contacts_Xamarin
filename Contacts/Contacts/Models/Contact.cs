using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Contacts.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Adress { get; set; }
        public string FullInfo
        {
            get
            {
                return string.Format("{0} - {1} / {2}", Firstname, Lastname, Phonenumber);
            }
        }
    }
}
