using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class BlogsDTO
    {
        public bool HasNextPage { get; set; }
        public bool HasPrevPage { get; set; }
        public IEnumerable<Blog> BlogList { get; set; }
    }
}
