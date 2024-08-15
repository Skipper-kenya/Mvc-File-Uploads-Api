using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace file_uploads.Dtos
{
    public class UploadedFileDto
    {
        public HttpPostedFileBase Photo { get; set; }
    }
}