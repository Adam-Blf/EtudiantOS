using System;

namespace EtudiantOS.Models
{
    public class CoursEvent
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Summary { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string TimeRange => $"{Start:HH:mm} - {End:HH:mm}";
        public string DateDisplay => Start.ToString("dd/MM/yyyy");
    }
}
