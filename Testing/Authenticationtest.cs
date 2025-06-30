using NUnit.Framework;
using DAO.Services;
using CarConnect.Exceptions;
using Model;
using System.Collections.Generic;

namespace Testing
{
    [TestFixture]
    public class AuthenticationTest
    {
        private AuthenticationService authService;
        private CustomerService customerService;
        private VehicleService vehicleService;

        [SetUp]
        public void Setup()
        {
            authService = new AuthenticationService();
            customerService = new CustomerService();
            vehicleService = new VehicleService();
        }

        
        [Test]
        public void AuthenticateCustomer_InvalidCredentials_ShouldThrowException()
        {
            string invalidUsername = "nonexist";
            string invalidPassword = "any";

            Assert.Throws<AuthenticationException>(() =>
                authService.AuthenticateCustomer(invalidUsername, invalidPassword));
        }

        
        [Test]
        public void TestUpdatingCustomerInformation()
        {
            int customerId = 1; 
            Customer customer = customerService.GetCustomerById(customerId);
            Assert.That(customer, Is.Not.Null, "Customer not found.");

            string originalPhone = customer.PhoneNumber;
            customer.PhoneNumber = "8888888888";

            customerService.UpdateCustomer(customer);

            Customer updatedCustomer = customerService.GetCustomerById(customerId);
            Assert.That(updatedCustomer.PhoneNumber, Is.EqualTo("8888888888"));

            
            customer.PhoneNumber = originalPhone;
            customerService.UpdateCustomer(customer);
        }

        [Test]
        
        public void TestAddingNewVehicle()
        {
            int testVehicleId = 3001; 

            try
            {
                
                var existing = vehicleService.GetVehicleById(testVehicleId);

               
                Assert.Fail("Vehicle with this ID already exists.");
            }
            catch (VehicleNotFoundException)
            {
               
                Vehicle newVehicle = new Vehicle
                {
                    VehicleID = testVehicleId,
                    Make = "Honda",
                    Model = "City",
                    VehicleYear = 2024,
                    Color = "White",
                    RegistrationNumber = "TEST3001",
                    DailyRate = 1500.0,
                    Availability = true
                };

                vehicleService.AddVehicle(newVehicle);

                
                var added = vehicleService.GetVehicleById(testVehicleId);
                Assert.That(added, Is.Not.Null);
                Assert.That(added.Model, Is.EqualTo("City"));
            }
        }

        [Test]
        public void TestUpdatingVehicleDetails()
        {
            int vehicleId = 9999;
            Vehicle vehicle = vehicleService.GetVehicleById(vehicleId);
            Assert.That(vehicle, Is.Not.Null, "Vehicle not found for update.");

            double originalRate = vehicle.DailyRate;
            string originalColor = vehicle.Color;

            vehicle.DailyRate = 2000.0;
            vehicle.Color = "Black";

            vehicleService.UpdateVehicle(vehicle);

            Vehicle updatedVehicle = vehicleService.GetVehicleById(vehicleId);
            Assert.That(updatedVehicle.DailyRate, Is.EqualTo(2000.0));
            Assert.That(updatedVehicle.Color, Is.EqualTo("Black"));

           
            vehicle.DailyRate = originalRate;
            vehicle.Color = originalColor;
            vehicleService.UpdateVehicle(vehicle);
        }

        
        [Test]
        public void TestGetAvailableVehicles()
        {
            List<Vehicle> availableVehicles = vehicleService.GetAvailableVehicles();

            Assert.That(availableVehicles, Is.Not.Null);
            Assert.That(availableVehicles.Count, Is.GreaterThanOrEqualTo(0));

            foreach (var vehicle in availableVehicles)
            {
                Assert.That(vehicle.Availability, Is.True, $"Vehicle ID {vehicle.VehicleID} is marked unavailable.");
            }
        }

        
        [Test]
        public void TestGetAllVehicles()
        {
            
            ReportGenerator reportGenerator = new ReportGenerator(); 

            
            List<Vehicle> allVehicles = reportGenerator.GetAllVehicles(); 
            
            Assert.That(allVehicles, Is.Not.Null, "The vehicle list should not be null.");
            Assert.That(allVehicles.Count, Is.GreaterThanOrEqualTo(0), "Vehicle count should be 0 or more.");
        }

    }
}

