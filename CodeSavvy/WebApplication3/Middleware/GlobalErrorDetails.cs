using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSavvy.WebUI.Middleware
{
    public class GlobalErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
            => $"Status Code: {StatusCode}\nMessage: {Message}\n";
    }
}
