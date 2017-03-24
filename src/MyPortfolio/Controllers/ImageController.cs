using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections;

namespace MyPortfolio.Controllers
{
    public class ImageController : Controller
    {
        private string rootPath;

        public ImageController(string rootPath)
        {
            this.rootPath = rootPath;
        }

        public IEnumerable<string> GetImage(string id) =>
            Directory.GetFiles(rootPath + @"\lib\Images\" + id).Select(Path.GetFileName);
    }
}