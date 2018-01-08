using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo03_AzureStorage.Models;
using Demo03_AzureStorage.Utilities;
using Microsoft.AspNetCore.Http;

namespace Demo03_AzureStorage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile image)
        {
            if (image == null)
            {
                return BadRequest();
            }

            // 1. step - convert image to byte array
            byte[] imageBytes;
            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);
                imageBytes = stream.ToArray();
            }

            // 2. step - use Utilities/AzureStorageUtility.cs class to upload bytes to Azure storage

            // Move this data to configuration!!!!
            string storageAccountName = "csharpfer";
            string storageAccountKey = "LjVQujwELHihaRmAMgUq90DjTi4ygYCT9cHQPcdA45aNh05oWuafLT4IeELpG0fS1INZoy1B81JRN9WMYJeMsw==";
            string storageContainerName = "images";

            var uploader = new AzureStorageUtility(storageAccountName, storageAccountKey);
            var url = await uploader.Upload(storageContainerName, imageBytes);

            return RedirectToAction("Image", new { url = url });

        }

        public IActionResult Image(string url)
        {
            return View("Image", url);
        }
    }
}
