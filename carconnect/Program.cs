using System;
using DAO.Services;
using Model;

namespace CarConnectApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthenticationService authService = new AuthenticationService();
            CustomerService customerService = new CustomerService();
            AdminService adminService = new AdminService();
            VehicleService vehicleService = new VehicleService();
            ReservationService reservationService = new ReservationService();
            ReportGenerator reportGenerator = new ReportGenerator();

            while (true)
            {
                Console.WriteLine("\n==== CarConnect Main Menu ====");
                Console.WriteLine("1. Customer Services");
                Console.WriteLine("2. Admin Services");
                Console.WriteLine("3. Vehicle Services");
                Console.WriteLine("4. Reservation Services");
                Console.WriteLine("5. Report Generator");
                Console.WriteLine("6.Exit");
                Console.Write("Enter your choice: ");

                int mainChoice = int.Parse(Console.ReadLine());

                switch (mainChoice)
                {
                    case 1:
                        Console.WriteLine("\n-- Customer Login --");
                        Console.Write("Username: ");
                        string custUsername = Console.ReadLine();
                        Console.Write("Password: ");
                        string custPassword = Console.ReadLine();

                        try
                        {
                            var loggedCustomer = authService.AuthenticateCustomer(custUsername, custPassword);
                            Console.WriteLine($"Welcome, {loggedCustomer.FirstName}!");

                            Console.WriteLine("\n-- Customer Services --");
                            Console.WriteLine("1. Get Customer by ID");
                            Console.WriteLine("2. Get Customer by Username");
                            Console.WriteLine("3. Register Customer");
                            Console.WriteLine("4. Update Customer");
                            Console.WriteLine("5. Delete Customer");
                           
                            Console.Write("Choose option: ");
                            int c = int.Parse(Console.ReadLine());

                            switch (c)
                            {
                                case 1:
                                    Console.Write("Enter Customer ID: ");
                                    int cid = int.Parse(Console.ReadLine());
                                    var cust = customerService.GetCustomerById(cid);
                                    if (cust != null)
                                        Console.WriteLine(cust);
                                    else
                                        Console.WriteLine("Customer not found.");
                                    break;
                                case 2:
                                    Console.Write("Enter Username: ");
                                    string uname = Console.ReadLine();
                                    var user = customerService.GetCustomerByUsername(uname);
                                    if (user != null)
                                        Console.WriteLine(user);
                                    else
                                        Console.WriteLine("Customer not found.");
                                    break;
                                case 3:
                                    Customer newCust = new Customer();
                                    Console.Write("Enter Customer ID: "); newCust.CustomerID = int.Parse(Console.ReadLine());
                                    Console.Write("First Name: "); newCust.FirstName = Console.ReadLine();
                                    Console.Write("Last Name: "); newCust.LastName = Console.ReadLine();
                                    Console.Write("Email: "); newCust.Email = Console.ReadLine();
                                    Console.Write("Phone: "); newCust.PhoneNumber = Console.ReadLine();
                                    Console.Write("Address: "); newCust.Address = Console.ReadLine();
                                    Console.Write("Username: "); newCust.UserName = Console.ReadLine();
                                    Console.Write("Password: "); newCust.Password = Console.ReadLine();
                                    newCust.RegistrationDate = DateTime.Now;
                                    customerService.RegisterCustomer(newCust);
                                    Console.WriteLine("Customer registered.");
                                    break;
                                case 4:
                                    Console.Write("Enter ID to update: ");
                                    int upid = int.Parse(Console.ReadLine());
                                    var updateCust = customerService.GetCustomerById(upid);
                                    if (updateCust != null)
                                    {
                                        Console.Write("New Email: "); updateCust.Email = Console.ReadLine();
                                        Console.Write("New Phone: "); updateCust.PhoneNumber = Console.ReadLine();
                                        customerService.UpdateCustomer(updateCust);
                                        Console.WriteLine("Updated.");
                                    }
                                    else Console.WriteLine("Customer not found.");
                                    break;
                                case 5:
                                    Console.Write("Enter ID to delete: ");
                                    int delid = int.Parse(Console.ReadLine());
                                    customerService.DeleteCustomer(delid);
                                    Console.WriteLine("Deleted.");
                                    break;
                            }
                        }
                        catch (System.Exception ex)
                        {
                            Console.WriteLine("Authentication failed: " + ex.Message);
                        }
                        break;

                    case 2:
                        Console.WriteLine("\n-- Admin Login --");
                        Console.Write("Username: ");
                        string adminUsername = Console.ReadLine();
                        Console.Write("Password: ");
                        string adminPassword = Console.ReadLine();

                        try
                        {
                            var loggedAdmin = authService.AuthenticateAdmin(adminUsername, adminPassword);
                            Console.WriteLine($"Welcome, Admin {loggedAdmin.FirstName}!");

                            Console.WriteLine("\n-- Admin Services --");
                            Console.WriteLine("1. Get Admin by ID");
                            Console.WriteLine("2. Get Admin by Username");
                            Console.WriteLine("3. Register Admin");
                            Console.WriteLine("4. Update Admin");
                            Console.WriteLine("5. Delete Admin");
                            Console.Write("Choose option: ");
                            int a = int.Parse(Console.ReadLine());

                            switch (a)
                            {
                                case 1:
                                    Console.Write("Enter Admin ID: ");
                                    int aid = int.Parse(Console.ReadLine());
                                    var admin = adminService.GetAdminById(aid);
                                    if (admin != null)
                                        Console.WriteLine(admin);
                                    else
                                        Console.WriteLine("Admin not found.");
                                    break;
                                case 2:
                                    Console.Write("Enter Username: ");
                                    string auser = Console.ReadLine();
                                    var aobj = adminService.GetAdminByUsername(auser);
                                    if (aobj != null)
                                        Console.WriteLine(aobj);
                                    else
                                        Console.WriteLine("Admin not found.");
                                    break;
                                case 3:
                                    Admin newAdmin = new Admin();
                                    Console.Write("Enter Admin ID: ");
                                    newAdmin.AdminID = int.Parse(Console.ReadLine());

                                    Console.Write("First Name: "); newAdmin.FirstName = Console.ReadLine();
                                    Console.Write("Last Name: "); newAdmin.LastName = Console.ReadLine();
                                    Console.Write("Email: "); newAdmin.Email = Console.ReadLine();
                                    Console.Write("Phone: "); newAdmin.PhoneNumber = Console.ReadLine();
                                    Console.Write("Username: "); newAdmin.UserName = Console.ReadLine();
                                    Console.Write("Password: "); newAdmin.Password = Console.ReadLine();
                                    Console.Write("Role: "); newAdmin.Role = Console.ReadLine();
                                    newAdmin.JoinDate = DateTime.Now;
                                    adminService.RegisterAdmin(newAdmin);
                                    Console.WriteLine("Admin registered.");
                                    break;
                                case 4:
                                    Console.Write("Enter Admin ID to update: ");
                                    int upaid = int.Parse(Console.ReadLine());
                                    var updAdmin = adminService.GetAdminById(upaid);
                                    if (updAdmin != null)
                                    {
                                        Console.Write("New Role: "); updAdmin.Role = Console.ReadLine();
                                        adminService.UpdateAdmin(updAdmin);
                                        Console.WriteLine("Updated.");
                                    }
                                    else Console.WriteLine("Admin not found.");
                                    break;
                                case 5:
                                    Console.Write("Enter ID to delete: ");
                                    int adid = int.Parse(Console.ReadLine());
                                    adminService.DeleteAdmin(adid);
                                    Console.WriteLine("Deleted.");
                                    break;
                            }
                        }
                        catch (System.Exception ex)
                        {
                            Console.WriteLine("Authentication failed: " + ex.Message);
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n-- Vehicle Services --");
                        Console.WriteLine("1. Get Vehicle by ID");
                        Console.WriteLine("2. Get Available Vehicles");
                        Console.WriteLine("3. Add Vehicle");
                        Console.WriteLine("4. Update Vehicle");
                        Console.WriteLine("5. Delete Vehicle");
                        Console.Write("Choose option: ");
                        int v = int.Parse(Console.ReadLine());

                        switch (v)
                        {
                            case 1:
                                Console.Write("Enter Vehicle ID: ");
                                int vid = int.Parse(Console.ReadLine());
                                var vehicle = vehicleService.GetVehicleById(vid);
                                if (vehicle != null)
                                    Console.WriteLine(vehicle);
                                else
                                    Console.WriteLine("Vehicle not found.");
                                break;
                            case 2:
                                var vehicles = vehicleService.GetAvailableVehicles();
                                foreach (var vhl in vehicles)
                                    Console.WriteLine(vhl);
                                break;
                            case 3:
                                Vehicle newVehicle = new Vehicle();
                                Console.Write("Enter Vehicle ID: ");
                                newVehicle.VehicleID = int.Parse(Console.ReadLine());
                                Console.Write("Model: "); newVehicle.Model = Console.ReadLine();
                                Console.Write("Make: "); newVehicle.Make = Console.ReadLine();
                                Console.Write("Year: "); newVehicle.VehicleYear = int.Parse(Console.ReadLine());
                                Console.Write("Color: "); newVehicle.Color = Console.ReadLine();
                                Console.Write("Registration Number: "); newVehicle.RegistrationNumber = Console.ReadLine();
                                Console.Write("Daily Rate: "); newVehicle.DailyRate = double.Parse(Console.ReadLine());
                                newVehicle.Availability = true;
                                vehicleService.AddVehicle(newVehicle);
                                Console.WriteLine("Vehicle added.");
                                break;
                            case 4:
                                Console.Write("Enter Vehicle ID to update: ");
                                int upVid = int.Parse(Console.ReadLine());
                                var updVehicle = vehicleService.GetVehicleById(upVid);
                                if (updVehicle != null)
                                {
                                    Console.Write("New Color: "); updVehicle.Color = Console.ReadLine();
                                    Console.Write("New Daily Rate: "); updVehicle.DailyRate = double.Parse(Console.ReadLine());
                                    vehicleService.UpdateVehicle(updVehicle);
                                    Console.WriteLine("Updated.");
                                }
                                else Console.WriteLine("Vehicle not found.");
                                break;
                            case 5:
                                Console.Write("Enter Vehicle ID to remove: ");
                                int delVid = int.Parse(Console.ReadLine());
                                vehicleService.DeleteVehicle(delVid);
                                Console.WriteLine("Vehicle removed.");
                                break;
                        }
                        break;


                    case 4:
                        Console.WriteLine("\n-- Reservation Services --");
                        Console.WriteLine("1. Create Reservation");
                        Console.WriteLine("2. Get Reservation by ID");
                        Console.WriteLine("3. Get Reservations by Customer ID");
                        Console.WriteLine("4. Update Reservation");
                        Console.WriteLine("5. Cancel Reservation");
                        Console.Write("Choose option: ");
                        int r = int.Parse(Console.ReadLine());

                        switch (r)
                        {
                            case 1:
                                Reservation newRes = new Reservation();
                                Console.Write("Enter Reservation ID: ");
                                newRes.ReservationID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Customer ID: ");
                                newRes.CustomerID = int.Parse(Console.ReadLine());
                                Console.Write("Enter Vehicle ID: ");
                                newRes.VehicleID = int.Parse(Console.ReadLine());
                                Console.Write("Start Date (yyyy-MM-dd): ");
                                newRes.StartDate = DateTime.Parse(Console.ReadLine());
                                Console.Write("End Date (yyyy-MM-dd): ");
                                newRes.EndDate = DateTime.Parse(Console.ReadLine());
                                Console.Write("Daily Rate: ");
                                double rate = double.Parse(Console.ReadLine());

                                
                                newRes.TotalCost = reservationService.CalculateTotalCost(newRes.StartDate, newRes.EndDate, rate);
                                newRes.Status = "Booked";

                                


                                reservationService.AddReservation(newRes);
                                Console.WriteLine("Reservation created successfully.");
                                break;

                            case 2:
                                Console.Write("Enter Reservation ID: ");
                                int rid = int.Parse(Console.ReadLine());
                                var res = reservationService.GetReservationById(rid);
                                if (res != null)
                                    Console.WriteLine(res);
                                else
                                    Console.WriteLine("Reservation not found.");
                                break;
                            case 3:
                                Console.WriteLine("\n-- All Reservations --");
                                var reservations = reservationService.GetAllReservations();
                                if (reservations.Count > 0)
                                {
                                    foreach (var rsv in reservations)
                                        Console.WriteLine(rsv);
                                }
                                else
                                {
                                    Console.WriteLine("No reservations found.");
                                }
                                break;

                            case 4:
                                Console.Write("Enter Reservation ID to update: ");
                                int updateId = int.Parse(Console.ReadLine());
                                var updateRes = reservationService.GetReservationById(updateId);
                                if (updateRes != null)
                                {
                                    Console.Write("New End Date (yyyy-MM-dd): ");
                                    updateRes.EndDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("New Daily Rate: ");
                                    double newRate = double.Parse(Console.ReadLine());

                                    
                                    updateRes.TotalCost = reservationService.CalculateTotalCost(updateRes.StartDate, updateRes.EndDate, newRate);

                                    reservationService.UpdateReservation(updateRes);
                                    Console.WriteLine("Reservation updated.");
                                }
                                else Console.WriteLine("Reservation not found.");
                                break;

                                

                            case 5:
                                Console.Write("Enter Reservation ID to cancel: ");
                                int cancelId = int.Parse(Console.ReadLine());
                                reservationService.CancelReservation(cancelId);
                                Console.WriteLine("Reservation cancelled.");
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("\n-- Report Options --");
                        Console.WriteLine("1. View All Reservations");
                        Console.WriteLine("2. View All Vehicles");
                        Console.Write("Choose option: ");
                        int reportChoice = int.Parse(Console.ReadLine());

                        switch (reportChoice)
                        {
                            case 1:
                                var reservations = reportGenerator.GetAllReservations();
                                foreach (var rv in reservations)
                                {
                                    Console.WriteLine(rv);
                                }
                                break;

                            case 2:
                                var vehicles = reportGenerator.GetAllVehicles();
                                foreach (var vr in vehicles)
                                {
                                    Console.WriteLine(vr);
                                }
                                break;


                            default:
                                Console.WriteLine("Invalid report option.");
                                break;
                        }
                        break;



                    case 6:
                        Console.WriteLine("Exiting CarConnect.");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
