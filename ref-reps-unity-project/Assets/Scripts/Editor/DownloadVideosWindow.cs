using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class DownloadVideosWindow : EditorWindow
{
    private Database _database = new Database();
    
    [MenuItem("Tools/Download lesson videos")]
    public static void CreateWindow()
    {
        GetWindow<DownloadVideosWindow>();
    }

    private async void OnGUI()
    {
        _database = new Database();
        if (GUILayout.Button("Download"))
        {
            //_database.DownloadFile("test_files/test.mp4");
            Debug.Log("before");
            var result = await _database.ReadTestValue();
            Debug.Log("after");
            Debug.Log("Result: "+result);
        }
    }
}
