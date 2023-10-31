﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient_Helper.Model
{
    public class HttpRequestResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Error { get; set; }
    }
}
