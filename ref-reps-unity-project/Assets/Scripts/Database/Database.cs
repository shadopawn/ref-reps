using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Database : MonoBehaviour
{
    public void DownloadFile(String path)
    {
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference
            reference = storage.GetReference(path);

        String fileName = Path.GetFileName(path);
        Debug.Log(fileName);

        string local_url = Application.dataPath +"/VideoFiles/"+ fileName;
        Debug.Log(local_url);

        // Download to the local filesystem
        reference.GetFileAsync(local_url).ContinueWith(task =>
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
