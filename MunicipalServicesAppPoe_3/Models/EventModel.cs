using System;

namespace MunicipalServicesAppPoe3.Models
{
    [Serializable]
    public class EventModel : IComparable<EventModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Attended { get; set; }

        public int CompareTo(EventModel other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}
