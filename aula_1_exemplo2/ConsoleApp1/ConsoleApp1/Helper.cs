using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Helper
    {
        public async Task<int> SenderAsync(string key)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://fiap-inaugural.azurewebsites.net/fiap");
            request.Headers.Add("Cookie", "ARRAffinity=aceb604967b96774235747709a20996e1ae54dbbc84233a2f5efee5d4a50cc07; ARRAffinitySameSite=aceb604967b96774235747709a20996e1ae54dbbc84233a2f5efee5d4a50cc07");
            var content = new StringContent("{\n  \"key\": \""+ key + "\"\n}\n", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return (int)response.StatusCode;
        }
    }
}
