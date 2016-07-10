using System;
using System.ServiceModel.Description;
using WCF.Playing.Extensions.ParameterInspectors;

namespace WCF.Playing.Extensions.Behaviors
{
    public class MyOperationBehaviorAttribute : Attribute, IOperationBehavior
    {
        #region IOperationBehavior

        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            Console.WriteLine("MyOperationBehaviorAttribute.AddBindingParameters() " + operationDescription.Name);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
            Console.WriteLine("MyOperationBehaviorAttribute.ApplyClientBehavior() " + operationDescription.Name);

            clientOperation.ClientParameterInspectors.Add(new MyParameterInspector("[Client]"));
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            Console.WriteLine("MyOperationBehaviorAttribute.ApplyDispatchBehavior() " + operationDescription.Name);

            dispatchOperation.ParameterInspectors.Add(new MyParameterInspector("[Server]"));
        }

        public void Validate(OperationDescription operationDescription)
        {
            Console.WriteLine("MyOperationBehaviorAttribute.Validate() " + operationDescription.Name);
        }

        #endregion
    }
}
