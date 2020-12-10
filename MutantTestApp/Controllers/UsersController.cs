using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using MutantTestApp.Models;

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

        public string saveUsers(string json)
        {
            string result = string.Empty;

            try
            {
                List<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json);
            }
            catch(Exception ex)
            {
                result = ex.Message + " - " + ex.StackTrace;
            }

            return result;
        }
    }
}
