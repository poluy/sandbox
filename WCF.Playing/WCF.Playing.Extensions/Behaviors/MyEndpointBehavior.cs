using System;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace WCF.Playing.Extensions.Behaviors
{
    public class MyEndpointBehavior: BehaviorExtensionElement, IEndpointBehavior
    {

        public override Type BehaviorType
        {
            get { return typeof (MyEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return this;
        }


        #region IEndpointBehavior

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            Console.WriteLine("MyEndpointBehavior.AddBindingParameters() " + endpoint.Address);
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            //endpoint.Contract.Behaviors.Insert(0, new MyContractBehavior());            
            Console.WriteLine("MyEndpointBehavior.ApplyClientBehavior() " + endpoint.Address);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            Console.WriteLine("MyEndpointBehavior.ApplyDispatchBehavior() " + endpoint.Address);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            Console.WriteLine("MyEndpointBehavior.Validate() " + endpoint.Address);
        }

        #endregion
    }
}
