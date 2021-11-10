using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDBContext appDBContext;

        public BlogRepository(AppDBContext _appDBContext)
        {
            appDBContext = _appDBContext;
        }
        public async Task<Blog> AddBlog(Blog blog)
        {            
            var result = await appDBContext.Blogs.AddAsync(blog);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteBlog(int blogid)
        {
            int deleted = 0;
            var result = await appDBContext.Blogs
                .FirstOrDefaultAsync(b => b.BlogId == blogid);

            if (result != null)
            {
                appDBContext.Blogs.Remove(result);
                deleted = await appDBContext.SaveChangesAsync();
            }

            return deleted;
        }

        public async Task<Blog> GetBlog(int blogid)
        {
            Blog blog = await appDBContext.Blogs
                .Join(
                    appDBContext.Users, 
                    b => b.UserId, 
                    u => u.UserId,
                    (b,u) => new Blog { 
                        BlogId = b.BlogId,
                        Title = b.Title,
                        Summary = b.Summary,  
                        Body = b.Body,
                        UserId = b.UserId,
                        CreatedAt = b.CreatedAt,
                        UpdatedAt = b.UpdatedAt,
                        CreatedBy = u.FirstName + " " + u.LastName
                    })
                .FirstOrDefaultAsync(b => b.BlogId == blogid);

            return blog;
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await appDBContext.Blogs
                .Join(
                    appDBContext.Users,
                    b => b.UserId,
                    u => u.UserId,
                    (b, u) => new Blog
                    {
                        BlogId = b.BlogId,
                        Title = b.Title,
                        Summary = b.Summary,
                        Body = b.Body,
                        UserId = b.UserId,
                        CreatedAt = b.CreatedAt,
                        UpdatedAt = b.UpdatedAt,
                        CreatedBy = u.FirstName + " " + u.LastName
                    })
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetBlogsByUserid(int userid)
        {
            IQueryable<Blog> query = appDBContext.Blogs;
            query.Where(b => b.UserId == userid);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Blog>> SearchBlogs(string searchTerm)
        {
            IQueryable<Blog> query = appDBContext.Blogs;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query
                    .Join(
                    appDBContext.Users,
                    b => b.UserId,
                    u => u.UserId,
                    (b, u) => new Blog
                    {
                        BlogId = b.BlogId,
                        Title = b.Title,
                        Summary = b.Summary,
                        Body = b.Body,
                        CreatedAt = b.CreatedAt,
                        UpdatedAt = b.UpdatedAt,
                        UserId = b.UserId,
                        CreatedBy = u.FirstName + " " + u.LastName
                    })
                    .Where(b => b.Title.ToLower().Contains(searchTerm)
                            || b.Summary.ToLower().Contains(searchTerm));
            }

            /*if ( != null)
            {
                query = query.Where(e => e == );
            }*/
            IEnumerable<Blog> list = null;
            list = await query.ToListAsync();
            if (list != null && list.Count() > 0)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        public async Task<Blog> UpdateBlog(Blog blog)
        {
            var result = await appDBContext.Blogs
                .FirstOrDefaultAsync(b => b.BlogId == blog.BlogId);

            if (result != null)
            {
                result.Title = blog.Title;
                result.Summary = blog.Summary;
                result.Body = blog.Body;
                result.UpdatedAt = DateTime.Now;

                await appDBContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<BlogsDTO> GetPaginatedBlogs(int pagenum, int pagesize)
        {
            IQueryable<Blog> query = appDBContext.Blogs
                                        .Join(
                                            appDBContext.Users,
                                            b => b.UserId,
                                            u => u.UserId,
                                            (b, u) => new Blog
                                            {
                                                BlogId = b.BlogId,
                                                Title = b.Title,
                                                Summary = b.Summary,
                                                Body = b.Body,
                                                CreatedAt = b.CreatedAt,
                                                UpdatedAt = b.UpdatedAt,
                                                UserId = b.UserId,
                                                CreatedBy = u.FirstName + " " + u.LastName
                                            }).OrderByDescending(x => x.UpdatedAt);

            PaginatedList<Blog> list = await PaginatedList<Blog>.CreateAsync(query, pagenum, pagesize);
            
            BlogsDTO dto = new BlogsDTO();

            dto.BlogList = list.ToList();
            dto.HasNextPage = list.HasNextPage;
            dto.HasPrevPage = list.HasPreviousPage;

            return dto;
        }
    }
}
