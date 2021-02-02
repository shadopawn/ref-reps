using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CallImageDownloader : MonoBehaviour
{
    private RawImage _callIcon;

    private Database _database = new Database();
    
    void Start(){
        _callIcon = GetComponentInChildren<RawImage>();
    }

    public async Task SetImage(String filename)
    {
        String iconURL = await _database.GetIconURL(filename);
        StartCoroutine(DownloadImage(iconURL));
    }

    IEnumerator DownloadImage(string url)
    {   
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if(request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            _callIcon.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
    } 

}
