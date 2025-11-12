using System;

namespace MunicipalServicesAppPoe3.Models
{
    [Serializable]
    public class IssueReport : IComparable<IssueReport>
    {
        public int Id { get; set; }
        public string ReporterName { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime DateReported { get; set; } = DateTime.Now;

        public int CompareTo(IssueReport other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
