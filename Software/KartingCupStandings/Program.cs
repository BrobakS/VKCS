using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace KartingCupStandings
{
    class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();
                try
                {
                    System.Diagnostics.Process.Start(@"WebFrontEnd\index.html");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + @"     WebFrontEnd\index.html");
                }
                Console.WriteLine("Server running");
                Console.ReadLine();
            }
        }
    }
}
