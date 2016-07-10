using System;
using System.Configuration;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace WCF.Playing.Extensions.Behaviors
{
    public class MyServiceBehaviorAttribute : BehaviorExtensionElement, IServiceBehavior
    {
        public override Type BehaviorType
        {
            get { return typeof (MyServiceBehaviorAttribute); }
        }

        protected override object CreateBehavior()
        {
            return this;
        }


        [ConfigurationProperty("messageName", DefaultValue = "default")]
        public string MessageName
        {
            get { return (string)base["messageName"]; }
        }

        #region IServiceBehavior


        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            Console.WriteLine("MyServiceBehaviorAttribute.AddBindingParameters()");
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            //serviceDescription.Endpoints[0].Contract.Behaviors.Add(new MyContractBehavior());
            Console.WriteLine("MyServiceBehaviorAttribute.ApplyDispatchBehavior()");
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            Console.WriteLine("MyServiceBehaviorAttribute.Validate()");
        }

        #endregion
    }
}
