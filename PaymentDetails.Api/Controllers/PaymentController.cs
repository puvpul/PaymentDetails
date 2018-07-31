using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PaymentDetails.Model;
using PaymentDetails.Repository;

namespace PaymentDetails.Api.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class PaymentController : ApiController
    {
        private IPaymentRepository _repository;
        public PaymentController(IPaymentRepository repository)
        {
            _repository = repository;
        }
        [ResponseType(typeof(PaymentDetail))]
        public IHttpActionResult Post([FromBody]PaymentDetail model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("no payment data available");
                }
                var newPayment = _repository.Save(model);

                return Ok(newPayment);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            

        }
    }
}
