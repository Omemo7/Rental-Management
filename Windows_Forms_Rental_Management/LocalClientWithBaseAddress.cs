using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Forms_Rental_Management
{
    public static class LocalClientWithBaseAddress
    {
        public static HttpClient client;

        static LocalClientWithBaseAddress()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5007/api/");
            
        }

    }
}
