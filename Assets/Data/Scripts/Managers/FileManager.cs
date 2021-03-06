using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class FileManager : MonoBehaviour
{ 
    // When either a music or a sound file was loaded, we invoke the event with the corresponding soundclip
    public Action<AudioClip> RequestedSoundLoaded;
    public Action<AudioClip> RequestedMusicLoaded;
    private string _path;

    // Opening up file explorers
    public void OpenFileExplorer(){
        _path = EditorUtility.OpenFilePanel("Available Sounds", "F:/Audio Done/A test/", "mp3");
        StartCoroutine(GetSound());
    }
    public void OpenFileExplorerMusic(){
        _path = EditorUtility.OpenFilePanel("Available Sounds", "F:/Audio Done/", "mp3");
        StartCoroutine(GetMusic());
    }

    // Two methods to upload the chosen mp3
    IEnumerator GetSound(){
        using(UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(_path,AudioType.MPEG)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.Success){
                AudioClip requestedSound = DownloadHandlerAudioClip.GetContent(www);
                string[] s = www.url.Split("/");
                int index = s.Length;
                requestedSound.name = s[index-1];
                RequestedSoundLoaded?.Invoke(requestedSound);
                IDManager.id++;
            }
        }
    }
    IEnumerator GetMusic(){
        using(UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(_path,AudioType.MPEG)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.Success){
                AudioClip requestedSound = DownloadHandlerAudioClip.GetContent(www);
                string[] s = www.url.Split("/");
                int index = s.Length;
                requestedSound.name = s[index-1];
                RequestedMusicLoaded?.Invoke(requestedSound);
            }
        }
    }
}
