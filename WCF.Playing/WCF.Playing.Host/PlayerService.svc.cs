using System;
using System.Collections.Generic;
using System.ServiceModel.Dispatcher;
using WCF.Playing.Contracts;
using WCF.Playing.Extensions;

namespace WCF.Playing.Host
{
    //[MyServiceBehavior]
    public class PlayerService : IPlayerService
    {
        public GetPlayListResponse GetPlayList(GetPlayListRequest request)
        {
            var response = new GetPlayListResponse();



            //var tooLongString = new string('-', 640000);

            response.Traks = new List<Track>();
            response.Traks.Add(new Track
            {
                Description = "Description",
                Duration = TimeSpan.FromMinutes(123),
                ID= Guid.NewGuid(),
                Name = "Some name goes here"
            });

            return response;
        }


        public GetPlayListResponse GetPlayList2(GetPlayListRequest request)
        {
            throw new NotImplementedException();
        }


        public string GetPlayList2(string paramVal, ref string pareamRef, out string paramOut)
        {

            pareamRef = pareamRef + " [added value]";

            paramOut = "[setted value]";

            return "[returned value]";
        }
    }
}
