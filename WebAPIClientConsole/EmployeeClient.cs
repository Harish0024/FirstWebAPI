using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAPIClientConsole
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5225/");
        public static async Task CallGetAllEmployee()
        {
           using(var client=new HttpClient())
            {
                client.BaseAddress = uri;
                HttpResponseMessage response = await client.GetAsync("GetAllEmployees");
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode)
                {
                    string x=await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(x);
                }
            }
            
        }
    }
}
