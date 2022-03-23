namespace Projekt1.Models
{
    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }

        public Event(int id, string name, string date)
        {
            this.id=id;
            this.name=name;
            this.date=date;
        }

   

    }
}
