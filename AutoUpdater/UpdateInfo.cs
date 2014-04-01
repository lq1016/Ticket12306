using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AutoUpdater
{
    [Serializable]
    [XmlRoot("Config")]
    public class UpdateInfo
    {
        public string OldVersion { get; set; }
        public string NewVersion { get; set; }
        public string ExcuteName { get; set; }
        public string UpdateContent { get; set; }
        public List<string> FileList { get; set; }
        public string RootUrl { get; set; }
        public string ExcuteFileName { get; set; }
    }
}
