﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
