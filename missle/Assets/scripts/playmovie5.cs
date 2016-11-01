using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class playmovie5 : MonoBehaviour {
    List<WWW> arwww = new List<WWW>();//圖片陣列

    public RenderHeads.Media.AVProWindowsMedia.Demos.VcrDemo vcrdemo;
    public GameObject movie;
    public GameObject vcr;
    public string target  = @"C:\Users\chile109\Desktop\武裝\";
    string url = "";
    DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\chile109\Desktop\武裝\" + getFile.fileName.text);

    RawImage player;
    Texture2D img;
    public static int kj = 0;

    void Start()
    {
        kj = 0;
        player = GetComponent<RawImage>();
      
        for (int i = 0; i < Directory.GetFiles(@"C:\Users\chile109\Desktop\武裝\"+ getFile.fileName.text).Length; i++)
        {
            if (i <= dirInfo.GetFiles("*.jpg").Length - 1)
            {//取得jpg數量
                url = "file://" + target + getFile.fileName.text +  @"\images" + i + ".jpg";      //圖片路徑
                
                arwww.Add(new WWW(url));//加入圖片陣列
            }
            
        }

        
        StartCoroutine(loadPic(0));
    }
    IEnumerator loadPic(int mk)
    {
        WWW www = arwww[mk];
        yield return www;
        if (www.error != null)
        {

            yield break;

        }
        else
        {

            img = www.texture as Texture2D;

            player.texture = img;



        }
    }
    public void right()
    {
        kj += 1;
        timespanBar2.page_index += 1;
        if (kj > dirInfo.GetFiles("*.jpg").Length - 1)
        {
            movie.SetActive(true);
            vcr.SetActive(true);
            this.gameObject.SetActive(false);
        
        }
        else
        {
            StartCoroutine(loadPic(kj));
        }

    }
    public void left()
    {
        if (kj > 0)
        { //減少
            kj -= 1;
            timespanBar2.page_index -= 1;
            StartCoroutine(loadPic(kj));
        }
        
            
        
    }
}


