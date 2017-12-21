using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    //TODO: Add validation here. Move update logic here so that we can keep the controller skinny
    //TODO: Tie to user model and add authentication and authorization to silo user data
    #region snippet1
    public class Contact
    {
        public int Id { get; set; }

        // // user ID from AspNetUser table
        // public string UserID { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

    #endregion
}