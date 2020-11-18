using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class DownloadLessonVideos : EditorWindow
{
    [MenuItem("Tools/Download lesson videos")]
    public static void CreateWindow()
    {
        EditorWindow.GetWindow<DownloadLessonVideos>();
        Debug.Log(Application.dataPath);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Download"))
        {
            DownloadFileFromFirebase();
        }
    }

    private static void DownloadFileFromFirebase()
    {
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference
            reference = storage.GetReference("training_videos/file_example_MP4_1920_18MG.mp4");

        string local_url = Application.dataPath + "/VideoFiles/TestFirebase.mp4";

        // Download to the local filesystem
        reference.GetFileAsync(local_url).ContinueWith(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("File downloaded.");
            }
        });
    }
}
