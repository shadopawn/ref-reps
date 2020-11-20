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

    private void OnGUI()
    {
        _database = new Database();
        if (GUILayout.Button("Download"))
        {
            _database.DownloadFile("training_videos/file_example_MP4_1920_18MG.mp4");
        }
    }
}
