using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp
{
    public class Account
    {
        public virtual int Id { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual decimal Balance { get; set; }
    }
}
