using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Domain
{
    public class Event : Entity
    {
        private ISet<Tickets> _tickets = new HashSet<Tickets>();
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<Tickets> Tickets => _tickets;
        public IEnumerable<Tickets> PurchatesTickets => Tickets.Where(x=>x.Purchased == true);
        public IEnumerable<Tickets> AvailiableTickets => Tickets.Except(PurchatesTickets);
        
        protected Event()
        {

        }

        public Event(Guid id,string name, string description, DateTime startDate, DateTime endDate)
        {
            Id = id;
            SetName(name);
            SetDescription(description);
            StartDate = startDate;
            EndDate = endDate;
            CreateAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Event with id: {Id} can not have an empty name.");
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetDescription(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc))
            {
                throw new Exception($"Event with id: {Id} can not have an empty description.");
            }
            Description = desc;
            UpdatedAt = DateTime.UtcNow;
        }
        public void AddTickets(int amount,decimal price)
        {
            var seating = _tickets.Count + 1;
            for (int i = 0; i < amount; i++)
            {
                _tickets.Add(new Tickets(this, seating ,price ));
                seating++;
            }
        }
        
    }
}
