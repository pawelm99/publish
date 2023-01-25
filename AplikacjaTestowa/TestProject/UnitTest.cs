using Application.Core.Domain;
using System;
using Xunit;

namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public void UserCreateTest()
        {
            var guid = Guid.NewGuid();
            
            var user = new User(guid,"nwm","Tomek","tomek@tomek.pl","password");
            var @event = new Event(guid, "Wydarzenie", "....", DateTime.UtcNow.AddDays(2), DateTime.UtcNow.AddDays(4));
            var ticket = new Tickets(@event, 10, 1);

            @event.Add(10, 10);

            Assert.NotNull(user);
            Assert.NotNull(@event);
            Assert.NotNull(ticket);
            Assert.Equal(@event.Id, ticket.EventId);
            Assert.Equal(10, ticket.Seating);
            Assert.Equal(@event.Id, ticket.EventId);
            


        }
    }
}