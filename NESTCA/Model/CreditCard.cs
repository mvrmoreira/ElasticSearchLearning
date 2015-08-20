using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESTCA.Model
{
    public class CreditCard
    {
        public Guid InstantBuyKey { get; set; }

        public string Brand { get; set; }

        public Buyer Buyer { get; set; }
    }
}
