using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpEditor.Models
{
    public class CompileResult
    {
        public CompileResult()
        {
            Messages = new List<string>();
        }
        public bool Success { get; set; }
        public List<string> Messages { set; get; }
    }

    
}