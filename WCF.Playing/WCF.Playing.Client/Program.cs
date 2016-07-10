using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Playing.Contracts;
using WCF.Playing.Extensions;

namespace WCF.Playing.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ExampleChannelFactory();
            }
            catch (Exception ex)
            {
            }
        }


        public static void ExampleChannelFactory()
        {
            //using (var channelFactory = new ChannelFactory<IPlayerService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:53124/PlayerService.svc")))
            using (var channelFactory = new ChannelFactory<IPlayerService>("name1"))
            {
                //channelFactory.Endpoint.Behaviors.Add(new MyEndpointBehavior());

                var channel = channelFactory.CreateChannel();
                
                var request = new GetPlayListRequest()
                {
                    FilterName = "some fileer",
                    ID = Guid.NewGuid(),
                    StartDate = DateTime.Now
                };


               Trace.CorrelationManager.ActivityId = Guid.NewGuid();
                
                //var response = channel.GetPlayList(request);


                var paramRef = "paramRef";
                var paramOut = "paramOut";

                var result = channel.GetPlayList2("paramVal", ref paramRef, out paramOut);


                ((IDisposable)channel).Dispose();
            }

            Console.ReadKey();
        }



        public static void ExampleStaticChannelFactory()
        {
            var channel = ChannelFactory<IPlayerService>.CreateChannel(new BasicHttpBinding(), new EndpointAddress("http://localhost:53124/PlayerService.svc"));


            var request = new GetPlayListRequest()
            {
                FilterName = "some fileer",
                ID = Guid.NewGuid(),
                StartDate = DateTime.Now
            };

            var response = channel.GetPlayList(request);

        }
    }
}
