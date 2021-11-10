using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public interface IBlogService
    {
        Task<ResponseDTO> CreateBlog(Blog blog);
        Task<ResponseDTO> DeleteBlog(int id);
        Task<IEnumerable<Blog>> GetAllBlogs();
        Task<ResponseDTO> GetBlog(int id);
        Task<ResponseDTO> UpdateBlog(Blog blog);
        Task<ResponseDTO> GetBlogsByUserid();
        Task<IEnumerable<Blog>> SearchBlogs(string search_phrase);

        Task<BlogsDTO> GetPaginatedBlogs(int pagenum, int pagesize);
    }
}