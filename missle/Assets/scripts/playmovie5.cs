using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class playmovie5 : MonoBehaviour {
    List<WWW> arwww = new List<WWW>();//圖片陣列

    public GameObject movie;
    public string target  = @"C:\Users\chile109\Desktop\武裝\";
    string url = "";
    DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\chile109\Desktop\武裝\" + getFile.fileName.text);

    RawImage player;
    Texture2D img;
    private int k = 0;

    void Start()
    {
        player = GetComponent<RawImage>();
      
        for (int i = 0; i < Directory.GetFiles(@"C:\Users\chile109\Desktop\武裝\"+ getFile.fileName.text).Length; i++)
        {
            if (i <= dirInfo.GetFiles("*.jpg").Length - 1)
            {//取得jpg數量
                url = "file://" + target + getFile.fileName.text +  @"\images" + i + ".jpg";      //圖片路徑
                print(url);
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
    void Update()
    {
        if(k == dirInfo.GetFiles("*.jpg").Length - 1)
        {
            this.gameObject.SetActive(false);
            movie.SetActive(true);
        }
    }
    public void right()
    {
        k += 1;
        if (k > dirInfo.GetFiles("*.jpg").Length - 1)
        {
            k = dirInfo.GetFiles("*.jpg").Length - 1;
            print(k);
        }
        else 
           StartCoroutine(loadPic(k));
        

    }
    public void left()
    {
        if (k > 0)
        { //減少
            k -= 1;
    
            StartCoroutine(loadPic(k));
            
        }
    }
}


