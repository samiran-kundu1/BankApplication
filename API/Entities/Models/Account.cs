using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; } = 0;
        
        //Specific User to which the account belongs to
        public int UserId { get; set; }

    }
}
