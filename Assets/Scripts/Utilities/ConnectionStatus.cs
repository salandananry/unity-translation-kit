using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine;

public class ConnectionStatus
{
    public static async Task<bool> HasConnection()
    {
        if (!IsNetworkReachable()) return false;
        return await CheckConnection();
    }

    private static async Task<bool> CheckConnection()
    {
        using (UnityWebRequest request = UnityWebRequest.Head("https://google.com"))
        {
            request.timeout = 3;
            var operation = request.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();
            bool result = request.result == UnityWebRequest.Result.Success;
            DebugHandler.Log(result);
            return result;
        }
    }
    private static bool IsNetworkReachable()
    {
        return Application.internetReachability != NetworkReachability.NotReachable;
    }
}