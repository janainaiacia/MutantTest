using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using MutantTestApp.Models;
using Newtonsoft.Json;

namespace MutantTestApp.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public async Task<string> getUsers()
        {
            string URI = "https://jsonplaceholder.typicode.com/users";
            string jsonUser = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        jsonUser = await response.Content.ReadAsStringAsync();

                    }
                    else
                    {
                        jsonUser = "Erro ao acessar Web API";
                    }
                }
            }
            return jsonUser;
        }

        public async Task<string> saveUsers(string json)
        {
            string result = string.Empty;

            try
            {
                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);              
              
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44335");
                    users = users.Where(x => x.Address.Suite.Contains("Suite")).ToList();

                    for (int i = 0; i < users.Count; i++)
                    {
                        var serializedUser = JsonConvert.SerializeObject(users[i]);
                        var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");

                        HttpResponseMessage responseMessage = await client.PostAsync("/api/Users", content);

                        if (responseMessage.IsSuccessStatusCode)
                        {
                            result = "OK";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message + " - " + ex.StackTrace;
            }

            return result;
        }
    }
}
