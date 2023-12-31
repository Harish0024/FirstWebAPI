﻿using FirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebAPIClientConsole
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5225/");
        public static async Task CallGetAllEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;

                HttpResponseMessage response = await client.GetAsync("GetAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string x = await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(x);
                }
            }

        }
        
            public static async Task jsonCallGetAllEmployee()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = uri;
                List<EmpViewModel> employee = new List<EmpViewModel>();
                client.DefaultRequestHeaders.
                    Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              

                //HttpGet
                    HttpResponseMessage response = await client.GetAsync("GetAllEmployees");
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                    String json=await response.Content.ReadAsStringAsync();
                    //install netwonsoft.json
                    employee=JsonConvert.DeserializeObject<List<EmpViewModel>>(json);
                    foreach(EmpViewModel emp in employee)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName}, {emp.LastName}");
                    }
                       
                    }
                }

            }
        public static async Task AddnewEmployee()
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModel employee = new EmpViewModel()
                {
                    FirstName = "William",
                    LastName = "john",
                    City = "nyc",
                    BirthDate = new DateTime(1980, 01, 01),
                    HireDate = new DateTime(2000, 01, 01),
                    Title = "Manager"
                };
                var myContent=JsonConvert.SerializeObject(employee);
                var buffer=Encoding.UTF8.GetBytes(myContent);
                var byteContent=new ByteArrayContent(buffer);
                byteContent.Headers.ContentType =
                    new MediaTypeHeaderValue("application/json");
                //httppost
                HttpResponseMessage response =
                    await client.PostAsync("addEmp", byteContent);
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }
            }
        }
        public static async Task UpdateEmployee(int empId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                EmpViewModel updatedEmployee = new EmpViewModel()
                {
                    EmpId = empId,
                    FirstName = "Sudharsan",
                    LastName = "A",
                    City = "Washington DC",
                    BirthDate = new DateTime(2000, 12, 01),
                    HireDate = new DateTime(2023, 08, 16),
                    Title = "DB Administrater",
                    ReportsTo = null

                };



                var myContent = JsonConvert.SerializeObject(updatedEmployee);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");



                // HttpPut or HttpPatch:
                HttpResponseMessage response = await client.PutAsync($"EditEmployee", byteContent); // Assuming the endpoint is named "UpdateEmployee"



                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync($"{response.StatusCode}");
                }
            }
        }
        public static async Task DeleteEmployee(int empId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;



                // HttpDelete:
                HttpResponseMessage response = await client.DeleteAsync($"DeleteEmployee?id={empId}"); // Assuming the endpoint is named "DeleteEmployee"



                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync($"{response.StatusCode}");
                }
            }
        }
    }
}
