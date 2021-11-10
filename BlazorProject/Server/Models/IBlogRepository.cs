using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetBlogs();
        Task<IEnumerable<Blog>> GetBlogsByUserid(int userid);
        Task<Blog> GetBlog(int blogid);
        Task<Blog> AddBlog(Blog blog);
        Task<Blog> UpdateBlog(Blog blog);
        Task<int> DeleteBlog(int blogid);
        Task<IEnumerable<Blog>> SearchBlogs(string searchTerm);

        Task<BlogsDTO> GetPaginatedBlogs(int pagenum, int pagesize);

    }
}
