using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Client.StateManagement;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlazorProject.Client.Services
{
    public class BlogService : IBlogService
    {
        private readonly UserState userstate;

        public BlogService(UserState _userstate)
        {
            userstate = _userstate;
        }
        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            IEnumerable<Blog> list = null;

            using (var httpClient = new HttpClient())
            {                
                using (var response = await httpClient.GetAsync("https://localhost:44384/view/blog/all"))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<IEnumerable<Blog>>(apiResponse);                    
                }
            }

            return list;

        }

        public async Task<ResponseDTO> GetBlog(int id)
        {
            //Blog blog = null;

            ResponseDTO rdto;

            using (var httpClient = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                //httpClient.DefaultRequestHeaders.Authorization = 
                //  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer","");
                using (var response = 
                    await httpClient.GetAsync("https://localhost:44384/view/blog/" + id.ToString()))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rdto = JsonConvert.DeserializeObject<ResponseDTO>(apiResponse);
                    
                }
            }

            return rdto;
        }

        public async Task<ResponseDTO> GetBlogsByUserid()
        {
            ResponseDTO respObj = null;

            using (var httpClient = new HttpClient())
            {
                IDictionary<string, object> dictobj = userstate.UserObj;
                Console.WriteLine(dictobj);
                
                StringContent content = 
                    new StringContent(JsonConvert.SerializeObject(
                        dictobj["claim1"].ToString()),                         
                        Encoding.UTF8, "application/json");
                
                httpClient.DefaultRequestHeaders.Authorization = 
                  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",userstate.Token);
                using (var response = await httpClient.PostAsync("https://localhost:44384/api/blog/GetBlogsByUserid", content))
                {
                    /*if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }*/
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    respObj = JsonConvert.DeserializeObject<ResponseDTO>(apiResponse);
                    
                }
            }

            return respObj;
        }

        public async Task<ResponseDTO> CreateBlog(Blog blog)
        {
            ResponseDTO rdto;
            int id = 0;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, "application/json");
                string token = userstate.Token;
                httpClient.DefaultRequestHeaders.Authorization =
                  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                using (var response =
                    await httpClient.PostAsync("https://localhost:44384/api/blog/createblog", content))
                {
                    /*if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {                        
                    }*/
                   
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    rdto = JsonConvert.DeserializeObject<ResponseDTO>(apiResponse);
                    //blog = blogsObj;
                }
            }
            return rdto;
        }

        public async Task<ResponseDTO> UpdateBlog(Blog blog)
        {
            ResponseDTO rdto;
            //Blog updatedblog;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, "application/json");
                string token = userstate.Token;
                httpClient.DefaultRequestHeaders.Authorization =
                  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                using (var response =
                    await httpClient.PutAsync("https://localhost:44384/api/blog/updateblog", content))
                {
                    /*if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }*/
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    rdto = JsonConvert.DeserializeObject<ResponseDTO>(apiResponse);
                    
                }
            }
            return rdto;
        }

        public async Task<ResponseDTO> DeleteBlog(int id)
        {
            ResponseDTO rdto;
            using (var httpClient = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, "application/json");
                string token = userstate.Token;
                httpClient.DefaultRequestHeaders.Authorization =
                  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                using (var response =
                    await httpClient.DeleteAsync("https://localhost:44384/api/blog/deleteblog/" + id.ToString()))
                {
                    /*if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }*/
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    rdto = JsonConvert.DeserializeObject<ResponseDTO>(apiResponse);
                }
            }

            return rdto;

        } 

        public async Task<IEnumerable<Blog>> SearchBlogs(string search_phrase)
        {
            IEnumerable<Blog> list = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44384/search/blog?q=" + search_phrase))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<IEnumerable<Blog>>(apiResponse);
                }
            }

            return list;
        }

        public async Task<BlogsDTO> GetPaginatedBlogs(int pagenum, int pagesize)
        {
            BlogsDTO blogsdto = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44384/view/blog/paginated?p=" + pagenum.ToString() + "&s=" + pagesize.ToString()))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blogsdto = JsonConvert.DeserializeObject<BlogsDTO>(apiResponse);
                }
            }


            return blogsdto;
        }
    }
}
