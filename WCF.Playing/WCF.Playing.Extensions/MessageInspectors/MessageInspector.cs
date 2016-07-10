using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace WCF.Playing.Extensions.MessageInspectors
{
    public class MessageInspector : IDispatchMessageInspector, IClientMessageInspector
    {
        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            var id = Guid.NewGuid();

            var soap = request.ToString();

            LogHelper.LogSoap(string.Format(">>> {0} MessageInspector.AfterReceiveRequest() {1}", id, channel.LocalAddress), soap);

            return id;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            var soap = reply.ToString();

            LogHelper.LogSoap(string.Format("<<< {0} MessageInspector.BeforeSendReply()", correlationState), soap);
        }

        #endregion

        #region IClientMessageInspector

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            var soap = reply.ToString();

            LogHelper.LogSoap(string.Format(">>> {0} MessageInspector.AfterReceiveReply()", correlationState), soap);
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            var id = Guid.NewGuid();

            var header = MessageHeader.CreateHeader("CustomHeader", "custom.policy.provider", "this is header value", false);

            request.Headers.Add(header);

            var soap = request.ToString();

            LogHelper.LogSoap(string.Format("<<< {0} MessageInspector.BeforeSendRequest() {1}", id, channel.LocalAddress), soap);

            return id;
        }

        #endregion
    }
}
