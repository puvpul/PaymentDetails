using PaymentDetails.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace PaymentDetails.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IPaymentRepository, PaymentRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}