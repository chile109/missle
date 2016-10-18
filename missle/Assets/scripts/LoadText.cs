using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class LoadText : MonoBehaviour {
    WWW trwww ;
    public getFile getFile;
    public string url = @"C:\Users\chile109\Desktop\";    
    public Text showText;

    void Start()
    {
        url = "file://" + url + getFile.fileName.text + ".txt";
        print(url);
        StartCoroutine(loadtxt(url));
    }
    IEnumerator loadtxt(string url)
    {
        
        trwww = new WWW(url);
            yield return trwww;
        if (trwww.error != null)
        {

            yield break;

        }
        else
        {
            showText.text = trwww.text;
           
        }
    }
}

