// See https://aka.ms/new-console-template for more information
using FirstWebAPI.Models;
using WebAPIClientConsole;

Console.WriteLine("API CLIENT");
//EmployeeAPIClient.jsonCallGetAllEmployee().Wait();

EmployeeAPIClient.DeleteEmployee(20).Wait();


Console.ReadLine();