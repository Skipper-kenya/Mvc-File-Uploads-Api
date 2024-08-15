using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace file_uploads.Models
{
    public class DbFilesModel
    {
      public int Id { get; set; }
      public byte[] Content { get; set; }
    }
}