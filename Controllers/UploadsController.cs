using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using file_uploads.Dtos;

namespace file_uploads.Controllers
{
    public class UploadsController : Controller
    {
        // GET: Uploads
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Upload(UploadedFileDto model)
        {
            var file = model.Photo;

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentType.Length > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extName = Path.GetExtension(file.FileName);
                    string uId = Guid.NewGuid().ToString();

                    string storageName = $"{fileName}_{uId}.{extName}";
                    string storagePath = Server.MapPath("~/wwwroot/Uploads");

                    if (!Directory.Exists(storagePath))
                    {
                        Directory.CreateDirectory(storagePath);
                    }

                    //using (var fs = new FileStream(storagePath, FileMode.Create))
                    //{
                    //    file.InputStream.CopyToAsync(fs);
                    //}

                    using (var memoryStream = new MemoryStream()) {
                          await file.InputStream.CopyToAsync(memoryStream);
                    }

                    ViewBag.UploadMessage = "Uploaded Successfully";

                    return RedirectToAction("Index", "Uploads");
                }


            }
            return RedirectToAction("Index", "Uploads");
        }
    }
}