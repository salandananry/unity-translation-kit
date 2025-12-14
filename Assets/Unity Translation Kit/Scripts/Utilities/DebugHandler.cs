using System.IO;
using System.Runtime.CompilerServices;

public class DebugHandler
{
    public static void Log(object message,
         [CallerFilePath] string file = "",
         [CallerMemberName] string method = "")
    {
        string scriptName = Path.GetFileNameWithoutExtension(file);
        UnityEngine.Debug.Log($"[{scriptName}][{method}] {message}");
    }

    public static void Warning(object message,
        [CallerFilePath] string file = "",
        [CallerMemberName] string method = "")
    {
        string scriptName = Path.GetFileNameWithoutExtension(file);
        UnityEngine.Debug.LogWarning($"[{scriptName}.{method}] {message}");
    }

    public static void Error(object message,
        [CallerFilePath] string file = "",
        [CallerMemberName] string method = "")
    {
        string scriptName = Path.GetFileNameWithoutExtension(file);
        UnityEngine.Debug.LogError($"[{scriptName}.{method}] {message}");
    }
}