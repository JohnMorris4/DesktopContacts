using SQLite;

namespace DesktopContacts.Models
{
    class Contacts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(75), Unique]
        public string Email { get; set; }


        public string PhoneNumber { get; set; }



    }
}
