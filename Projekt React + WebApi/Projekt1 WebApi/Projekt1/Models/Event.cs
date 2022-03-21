namespace Projekt1.Models
{
    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? date { get; set; }

        public Event(int id, string name, DateTime? date)
        {
            this.id=id;
            this.name=name;
            this.date=date;
        }

   

    }
}
