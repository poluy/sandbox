using System;
using System.ServiceModel.Description;
using WCF.Playing.Extensions.MessageInspectors;

namespace WCF.Playing.Extensions.Behaviors
{
    public class MyContractBehavior :  Attribute, IContractBehavior

    //public class MyContractBehavior : BehaviorExtensionElement, IContractBehavior
    {

        //public override Type BehaviorType
        //{
        //    get { return typeof (MyContractBehavior); }
        //}

        //protected override object CreateBehavior()
        //{
        //    return this;
        //}


        #region IContractBehavior

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            Console.WriteLine("MyContractBehavior.AddBindingParameters()");
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            Console.WriteLine("MyContractBehavior.ApplyClientBehavior()");
            clientRuntime.MessageInspectors.Add(new MessageInspector());
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
        {
            Console.WriteLine("MyContractBehavior.ApplyDispatchBehavior()");
            dispatchRuntime.MessageInspectors.Add(new MessageInspector());
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            Console.WriteLine("MyContractBehavior.Validate()");
        }

        #endregion

    }
}
