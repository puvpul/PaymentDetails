using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Web.Hosting;
using PaymentDetails.Model;
using Newtonsoft.Json;

namespace PaymentDetails.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        string filePath = HostingEnvironment.MapPath(@"~/Data/payment.json");
        List<PaymentDetail> allPaymentDetails = new List<PaymentDetail>();
        public PaymentDetail Save(PaymentDetail paymentDetail)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                paymentDetail.PaymentId = 1;
                allPaymentDetails.Add(paymentDetail);
                WriteToFile(allPaymentDetails);
            }
            else
            {
                allPaymentDetails = GetAll();
                paymentDetail.PaymentId = allPaymentDetails.Max(x => x.PaymentId) + 1;
                //paymentDetail.PaymentId = allPaymentDetails.Count > 0 ? allPaymentDetails.Max(x => x.PaymentId) + 1 : 1;
                allPaymentDetails.Add(paymentDetail);
                WriteToFile(allPaymentDetails);
            }
            
            return paymentDetail;
        }

        private bool WriteToFile(List<PaymentDetail> allPaymentDetails)
        {
            var json = JsonConvert.SerializeObject(allPaymentDetails, Formatting.Indented);
            File.WriteAllText(filePath, json);
            return true;
        }

        public List<PaymentDetail> GetAll()
        {
            List<PaymentDetail> paymentDetails = new List<PaymentDetail>();
            
            var json = File.ReadAllText(filePath);
            paymentDetails = JsonConvert.DeserializeObject<List<PaymentDetail>>(json);
            
            return paymentDetails;
        }
    }
}
