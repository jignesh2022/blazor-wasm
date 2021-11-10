using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class ResponseDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public  string DataType { get; set; }
        public dynamic Data { get; set; }
    }
}
