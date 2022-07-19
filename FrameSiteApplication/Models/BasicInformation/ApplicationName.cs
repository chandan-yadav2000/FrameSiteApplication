using System;

namespace FrameSiteApplication.Models.BasicInformation
{
    public class ApplicationName
    {
        public int pkid_ApplicationName { get; set; }

        public string applicationName { get; set; }

        public string applicationDiscription { get; set; }

        public byte[] applicatinLogo { get; set; }

        public DateTime lastUpdateDate { get; set; }
    }
}