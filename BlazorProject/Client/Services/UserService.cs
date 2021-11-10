using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using shared = BlazorProject.Shared;
using Newtonsoft.Json;
using BlazorProject.Client.StateManagement;


namespace BlazorProject.Client.Services
{
    public class UserService : IUserService
    {
        
        public async Task<string> Login(shared.Login login)
        {
            string token = null;
            
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                //httpClient.DefaultRequestHeaders.Authorization = 
                  //  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer","");
                using (var response = await httpClient.PostAsync("https://localhost:44384/api/user/login", content))
                {
                    if(response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return token;
                    }
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dynamic tokenObj= JsonConvert.DeserializeObject(apiResponse);
                    token = tokenObj.accessToken;               
                    


                }
            }

            return token;
        }

        public async Task<string> Register(shared.Register registerObj)
        {
            string response = null;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(registerObj), Encoding.UTF8, "application/json");
                //httpClient.DefaultRequestHeaders.Authorization = 
                //  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer","");
                using (var httpResponse = await httpClient.PostAsync("https://localhost:44384/api/user/register", content))
                {
                    //await httpResponse.Content.ReadAsStringAsync();
                    if(httpResponse.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        response = "New User Created";
                    }
                }
            }

            return response; 
        } 

        public async Task<bool> EmailExists(string email)
        {
            bool exists = false;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(new {Email=email}), Encoding.UTF8, "application/json");
                //httpClient.DefaultRequestHeaders.Authorization = 
                //  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer","");
                using (var httpResponse = await httpClient.PostAsync("https://localhost:44384/CheckIfEmailExists", content))
                {
                    string resp = await httpResponse.Content.ReadAsStringAsync();
                    
                    Console.WriteLine(resp);
                    if (resp == "exists")
                    {
                        exists = true;
                    }
                }
            }

            return exists;
        }
    }
}
