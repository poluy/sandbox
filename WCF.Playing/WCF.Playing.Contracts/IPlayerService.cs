using System.Runtime.InteropServices;
using System.ServiceModel;
using WCF.Playing.Extensions.Behaviors;

namespace WCF.Playing.Contracts
{
    [ServiceContract(Namespace = "https://WCF.Playing/services/api/2016/06")]
    [MyContractBehavior]
    public interface IPlayerService
    {
        [OperationContract]
        [MyOperationBehavior]
        GetPlayListResponse GetPlayList(GetPlayListRequest request);

        [OperationContract]
        [MyOperationBehavior]
        string GetPlayList2(string paramVal, ref string pareamRef, out string paramOut);

    }
}
