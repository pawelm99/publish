﻿using Evento.Core.Domain;
using Evento.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Event> GetOrFailAsync(this IEventRepository eventRepository,Guid id)
        {
            var @event = await eventRepository.GetAsync(id);
            if (@event == null)
            {
                throw new Exception($"Event with id: '{id}' does not exist.");
            }
            return @event;
        }
    }
}