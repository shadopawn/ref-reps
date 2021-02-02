using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Object = UnityEngine.Object;

public class Database
{
    public void DownloadFile(String path, String destination = "")
    {
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference reference = storage.GetReference(path);

        String fileName = Path.GetFileName(path);

        String localURL;
        if (destination == "")
        {
            localURL = Application.dataPath + "/VideoFiles/" + fileName;
        }
        else
        {
            localURL = destination;
        }

        // Download to the local filesystem
        reference.GetFileAsync(localURL).ContinueWith(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("File downloaded.");
            }
            else
            {
                Debug.LogError("File failed to download.");
            }
        });
    }

    public async Task<String> GetVideoURL(String fileName)
    {
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference reference = storage.GetReference("training_videos/"+fileName);

        String videoURL = "";
        await reference.GetDownloadUrlAsync().ContinueWith((Task<Uri> task) => {
            if (!task.IsFaulted && !task.IsCanceled) {
                videoURL = task.Result.ToString();
            }
        });
        return videoURL;
    }

    public async Task<String> GetIconURL(String fileName)
    {
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference reference = storage.GetReference("basketball_signals/"+fileName);

        String iconURL = "";
        await reference.GetDownloadUrlAsync().ContinueWith((Task<Uri> task) => {
            if (!task.IsFaulted && !task.IsCanceled) {
                iconURL = task.Result.ToString();
            }
        });
        return iconURL;
    }
    
    public async Task<String> GetLessonPacksJson()
    {
        String lessonPacks = "";
        await FirebaseDatabase.DefaultInstance
            .GetReference("lesson_packs")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted) {
                    // Handle the error...
                }
                else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    lessonPacks = snapshot.GetRawJsonValue();
                }
            });
        return lessonPacks;
    }
    
    public async Task<String> ReadTestValue()
    {
        String testResult = "";
        await FirebaseDatabase.DefaultInstance
            .GetReference("test")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted) {
                    // Handle the error...
                }
                else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    testResult = snapshot.Value.ToString();
                }
            });
        return testResult;
    }
}
