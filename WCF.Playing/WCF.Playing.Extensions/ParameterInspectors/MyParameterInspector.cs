using System;
using System.ServiceModel.Dispatcher;

namespace WCF.Playing.Extensions.ParameterInspectors
{
    public class MyParameterInspector : IParameterInspector
    {

        public MyParameterInspector(string message)
        {
            Message = message;
        }

        public string Message { get; set; }


        #region IParameterInspector

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Console.WriteLine("MyParameterInspector.AfterCall() " + operationName + "   " + correlationState);

            for (int i = 0; i < outputs.Length; i++)
            {
                if (outputs[i] is string)
                {
                    outputs[i] = ((string) outputs[i]) + Message + "AfterCall  ";
                }
            }
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            var id = Guid.NewGuid();

            Console.WriteLine("MyParameterInspector.AfterCall() " + operationName + "   " + id);

            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] is string)
                {
                    inputs[i] = ((string)inputs[i]) + Message + "BeforeCall  ";
                }
            }

            return id;
        }

        #endregion
    }
}
