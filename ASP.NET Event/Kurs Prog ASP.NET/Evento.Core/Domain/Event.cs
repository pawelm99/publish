using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Domain
{
    public class Event : Entity
    {
        private ISet<Ticket> _tickets = new HashSet<Ticket>();
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdateAt { get; protected set; }
        public IEnumerable<Ticket> Tickets => _tickets;
        public IEnumerable<Ticket> PurchatesTrickets => Tickets.Where(x=>x.Purchased);
        public IEnumerable<Ticket> AveliableTrickets => Tickets.Except(PurchatesTrickets);

        protected Event()
        {

        }
        public Event(Guid id, string name, string desc,int iloscBiletow, decimal price,DateTime start,DateTime end)
        {
            Id = id;
            SetName(name);
            SetDesc(desc);
            AddTickets(iloscBiletow,price);
            StartDate = start;
            EndDate = end;
            CreatedAt= DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;

        }
        public void AddTickets(int amount,decimal price)
        {
            var seating = _tickets.Count+1;
            for (int i = 0; i < amount; i++)
            {
                _tickets.Add(new Ticket(this, seating, price));
                seating--;
            }
        }

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Event with id: '{Id}' can not have an empty name.");
            }
            Name = name;
            UpdateAt= DateTime.UtcNow;
        }
        public void SetDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc))
            {
                throw new Exception($"Event with id: '{Id}' can not have an empty desc.");
            }
            Description = desc;
            
        }

        public void PurchatedTickets(User user, int amount)
        {
            if(AveliableTrickets.Count() < amount)
            {
                throw new Exception($"Not enough available tickets to purchase ({amount}) by user: {user.Name}");
            }
            var tickets = AveliableTrickets.Take(amount);
            foreach (var item in tickets)
            {
                item.Purchates(user);
            }

        }

        public void CancelPurchasedTickets(User user, int amount)
        {
            var tickets = GetTicketsPurchasedByUserId(user);
            if(tickets.Count() < amount)
            {
                throw new Exception($"Not enough purchased tickets to be canceled ({amount}) by user: {user.Name}");

            }
            foreach (var item in tickets.Take(amount))
            {
                item.Cancel();
            }
        }

        public IEnumerable<Ticket> GetTicketsPurchasedByUserId(User user)
            => PurchatesTrickets.Where(x => x.UserId == user.Id);

    }
}
