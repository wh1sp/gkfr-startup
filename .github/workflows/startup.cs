using UnityEngine;
using System.IO;

public class StartupExplorer : MonoBehaviour
{
    private void Awake()
    {
        InitializeExplorer();
    }

    private void InitializeExplorer()
    {
        UnityExplorer.Loader.Load();
        var inspector = new UnityExplorer.inspector();
        var gkNetMgrRoomType = inspector.FindType("GkNetMgr.room");
        if (gkNetMgrRoomType != null)
        {
            Debug.Log($"result: {gkNetMgrRoomType.FullName}");
            WriteToLogFile($"result: {gkNetMgrRoomType.FullName}");
        }
        else
        {
            Debug.LogError("didnt find it");
            WriteToLogFile("didnt find it");
        }
    }
    private void WriteToLogFile(string message)
    {
        string logFilePath = Path.Combine(Application.dataPath, "StartupLog.txt");
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {writer.WriteLine(message);}
    }
}
