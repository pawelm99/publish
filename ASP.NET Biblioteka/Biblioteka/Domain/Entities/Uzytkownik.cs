﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string  Haslo { get; set; }
        public string  HasloP { get; set; }
    }
    
}