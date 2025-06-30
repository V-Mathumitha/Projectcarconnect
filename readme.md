CarConnect - Console-Based Car Rental System

CarConnect is a C# console application for managing a car rental system. It supports customer login, vehicle registration, booking management, and admin operations, built using ADO.NET and SQL Server.

Technologies Used

- C# (.NET Framework)
- ADO.NET
- SQL Server
- Visual Studio 2022
- NUnit (for testing)

Project Structure

Projectcarconnect/
carconnect/       - Console UI and MainModule  
DAO/              - Data access (SQL)  
Exception/        - Custom exceptions  
Model/            - Entity classes  
Testing/          - NUnit test project  
Util/             - DB connection (DBConnUtil.cs)  
carconnect.sql    - SQL script to create tables  
carconnect.sln    - Solution file  
.gitignore        - Git ignore file  
README.md         - Project documentation  

Features

- Customer registration, login, update, delete  
- Admin operations (manage vehicles/customers)  
- Vehicle inventory (CRUD)  
- Reservation creation, update, cancel  
- Filter vehicles and view bookings  
- SQL Server DB integration using ADO.NET  
- Unit testing with NUnit  

Customer Services

- GetCustomerById(customerId)  
- GetCustomerByUsername(username)  
- RegisterCustomer(customerData)  
- UpdateCustomer(customerData)  
- DeleteCustomer(customerId)  

Vehicle Services

- GetVehicleById(vehicleId)  
- GetAvailableVehicles()  
- AddVehicle(vehicleData)  
- UpdateVehicle(vehicleData)  
- RemoveVehicle(vehicleId)  

Reservation Services

- GetReservationById(reservationId)  
- GetReservationsByCustomerId(customerId)  
- CreateReservation(reservationData)  
- UpdateReservation(reservationData)  
- CancelReservation(reservationId)  

Admin Services

- GetAdminById(adminId)  
- GetAdminByUsername(username)  
- RegisterAdmin(adminData)  
- UpdateAdmin(adminData)  
- DeleteAdmin(adminId)  

Custom Exceptions Used

AuthenticationException  
- Thrown when there is an issue with user authentication.

ReservationException  
- Thrown when a reservation cannot be made or modified.

VehicleNotFoundException  
- Thrown when a requested vehicle cannot be found in the system.

AdminNotFoundException  
- Thrown when an admin user record is not found.

InvalidInputException  
- Thrown when input data is invalid or missing.

DatabaseConnectionException  
- Thrown when there is an issue with the database connection.

Unit Testing with NUnit

Unit testing is essential to ensure the correctness and reliability of the system. The following test cases are covered:

1. Test customer authentication with invalid credentials.  
2. Test updating customer information.  
3. Test adding a new vehicle.  
4. Test updating vehicle details.  
5. Test getting a list of available vehicles.  
6. Test getting a list of all vehicles.  
