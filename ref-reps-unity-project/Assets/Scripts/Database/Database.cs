using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Database
{
    public void DownloadFile(String path, String destination = "")
    {
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference
            reference = storage.GetReference(path);

        String fileName = Path.GetFileName(path);

        String localURL = "";
        if (destination == "")
        {
            localURL = Application.dataPath + "/VideoFiles/"+ fileName;
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
}
