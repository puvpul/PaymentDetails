using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentDetails.Model;

namespace PaymentDetails.Repository
{
    public interface IPaymentRepository
    {
        PaymentDetail Save(PaymentDetail paymentDetails);
    }
}
