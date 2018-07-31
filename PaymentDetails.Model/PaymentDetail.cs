using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentDetails.Model
{
    public class PaymentDetail
    {
        public int PaymentId { get; set; }
        public int BSB { get; set; }
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
    }
}
