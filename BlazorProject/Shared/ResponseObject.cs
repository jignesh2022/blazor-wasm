﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class ResponseObject
    {
        public bool Success { get; set; }        
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
