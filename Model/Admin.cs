using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime JoinDate { get; set; }

        public Admin()
        {

        }
        public Admin(int AdminID,string FirstName,string LastName,string Email,string PhoneNumber,
            string UserName,string Password,String Role,DateTime JoinDate)
        {
            this.AdminID = AdminID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.UserName = UserName;
            this.Password = Password;
            this.Role = Role;
            this.JoinDate = JoinDate;

        }
        public override string ToString()
        {
            return $"AdminID: {AdminID}, Name: {FirstName} {LastName}, Email: {Email}, Role: {Role}";
        }




    }

}
