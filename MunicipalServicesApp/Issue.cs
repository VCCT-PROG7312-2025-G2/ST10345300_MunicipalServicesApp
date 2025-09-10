using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public DateTime DateReported { get; set; }

        public Issue(string location, string category, string description, string filePath)
        {
            Location = location;
            Category = category;
            Description = description;
            FilePath = filePath;
            DateReported = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{DateReported}: {Category} at {Location}";
        }
    }
}
