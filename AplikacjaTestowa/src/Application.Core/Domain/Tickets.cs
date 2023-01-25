using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Domain
{
    public class Tickets : Entity
    {
        public Guid EventId { get; protected set; }
        public int Seating { get; set; }
        public decimal Price { get; set; }
        public Guid? UserId { get; set; }
        public string Username { get; set; }
        public DateTime? PurchasedAt { get; set; }
        public bool Purchased => UserId.HasValue;

        protected Tickets()
        {

        }

        public Tickets(Event @event, int seating, decimal price)
        {
            EventId = @event.Id;
            Seating = seating;
            Price = price;
        }
    }
}
