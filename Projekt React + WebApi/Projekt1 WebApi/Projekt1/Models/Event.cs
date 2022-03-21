namespace Projekt1.Models
{
    public class Event
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime? date { get; set; }

        public Event(Guid id, string name, DateTime? date)
        {
            this.id=id;
            this.name=name;
            this.date=date;
        }

   

    }
}
