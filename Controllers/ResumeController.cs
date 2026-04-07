using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MyPortfolio.Controllers
{
    public class ResumeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public ResumeController(IWebHostEnvironment env) 
        { 
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            var filePath = Path.Combine(_env.WebRootPath,"files/resume.pdf");

            if (!System.IO.File.Exists(filePath)) {
                return NotFound("File not Found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", "Jeffrey_Alzate_Resume.pdf");
        }
    }
}
