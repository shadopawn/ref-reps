using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Database
{
    private String _testResult;

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
                Debug.LogError("File failed to download");
            }
        });
    }
    
    public async Task ReadTestValue()
    {
        await FirebaseDatabase.DefaultInstance
            .GetReference("test")
            .GetValueAsync().ContinueWith(task => {
                if (task.IsFaulted) {
                    // Handle the error...
                }
                else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    Debug.Log(snapshot.Value);
                    SetTestValue(snapshot.Value);
                }
            });
    }
    
    public void SetTestValue(object TestValue)
    {
        _testResult = TestValue.ToString();
    }

    public String GetTestValue()
    {
        return _testResult;
    }
}
