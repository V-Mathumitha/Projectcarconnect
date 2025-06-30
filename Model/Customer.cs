using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public  DateTime RegistrationDate { get; set; }

        public Customer()
        {

        }
        public Customer(int CustomerID, string FirstName, string LastName, string Email, string PhoneNumber, string Address, string UserName,
            string Password, DateTime RegistrationDate)
        {
            this.CustomerID = CustomerID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.UserName = UserName;
            this.Password = Password;
            this.RegistrationDate = RegistrationDate;
        }
        public override string ToString()
        {
            return $"CustomerID: {CustomerID}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber}, " +
                   $"Address: {Address}, Username: {UserName}, Registered On: {RegistrationDate.ToShortDateString()}";
        }






    }
}
