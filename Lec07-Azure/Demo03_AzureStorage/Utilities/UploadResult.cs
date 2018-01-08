using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo03_AzureStorage.Utilities
{
    public class UploadResult
    {
        public string Error { get; set; }

        public bool IsSuccess
        {
            get { return string.IsNullOrEmpty(Error); }
        }

        public string Url { get; set; }
    }
}
