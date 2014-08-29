using CSharpEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.CodeDom.Compiler;
using System.Text;
using Microsoft.CSharp;

namespace CSharpEditor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Compile(string data)
        {
            return View(CompileCode(data));
        }

        private CompileResult CompileCode(string code)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll"); 
            // Generate an executable instead of  
            // a class library.
            cp.GenerateExecutable = true; 
            
            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;

            // Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = false;

            // Invoke compilation of the source file.
            CompilerResults cr = provider.CompileAssemblyFromSource(cp,
                code);
            var result = new CompileResult { Success = cr.Errors.Count <= 0 };
            if (!result.Success)
            {
                foreach (CompilerError error in cr.Errors)
                {
                    var text = error.ErrorText;
                    int index =text.IndexOf(cr.PathToAssembly,StringComparison.OrdinalIgnoreCase);
                    if (index >=0)
                        text = text.Remove(index, cr.PathToAssembly.Length);
                    result.Messages.Add(error.Line + ":" +text);
                }
            }
            return result;
        }
    }
}