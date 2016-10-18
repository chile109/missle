using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class playmovie5 : MonoBehaviour {
    List<WWW> arwww = new List<WWW>();//圖片陣列
    List<WWW> mrwww = new List<WWW>();//影片陣列
    //public getFile getfile;
    string url = "";
    public string target = @"c:\Users\chile109\Desktop\" + getFile.fileName.text; 
    DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\chile109\Desktop\" + getFile.fileName.text);

    
    RawImage player;
    AudioSource sound;
    MovieTexture movie;
    Texture2D img;
    int k = 0;
    void Start()
    {
        player = GetComponent<RawImage>();
        sound = GetComponent<AudioSource>();
        for (int i = 0; i < Directory.GetFiles(target).Length; i++)
        {
            if (i <= dirInfo.GetFiles("*.jpg").Length - 1)
            {//取得jpg數量
                url = "file://" + target +@"\images" + i + ".jpg";      //圖片路徑
                arwww.Add(new WWW(url));//加入圖片陣列
            }
            if (dirInfo.GetFiles("*.jpg").Length - 1 < i && i <= Directory.GetFiles(target).Length)
            {//取得ogv數量
                int movCount = i - dirInfo.GetFiles("*.jpg").Length;
                url = "file://" + target + @"\movies" + movCount + ".ogv";      //影片路徑
                print(url);
                mrwww.Add(new WWW(url));//加入影片陣列
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
    IEnumerator loadMovie(int mk)
    {
        WWW www = mrwww[mk];
        while (www.isDone == false)
        {
            yield return 0;
        }

            movie = www.movie;
        while (movie.isReadyToPlay == false)
        {
            yield return 0;
        }
            
            player.texture = movie;
            sound.clip = movie.audioClip;

            movie.Play();
            sound.Play();

    }
  
    public void fullscreen()
    {
        player.rectTransform.anchoredPosition = new Vector2(0,0);
        player.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        
    }
    public void resize_screen()
    {
        player.rectTransform.anchoredPosition = new Vector2(185,0);
        player.rectTransform.sizeDelta = new Vector2(400,250);

    }

    public void right()
    {
        if (k < Directory.GetFiles(target).Length - 1)
        { //增加
            k += 1;
            if (dirInfo.GetFiles("*.jpg").Length <= k && k < Directory.GetFiles(target).Length)
            {
                StartCoroutine(loadMovie(k - dirInfo.GetFiles("*.jpg").Length));

            }
            else
            {
                StartCoroutine(loadPic(k));
            }
        }

    }
    public void left()
    {
        if (k > 0)
        { //減少
            k -= 1;
            if (dirInfo.GetFiles("*.jpg").Length <= k && k < Directory.GetFiles(target).Length)
            {
                StartCoroutine(loadMovie(k - dirInfo.GetFiles("*.jpg").Length));
            }
            else
            {
                StartCoroutine(loadPic(k));
            }
        }
    }
    void Update()
    {
        

        if (k < Directory.GetFiles(target).Length - 1 && Input.GetKeyDown(KeyCode.D))
        { //增加
            k += 1;
            
            if (dirInfo.GetFiles ("*.jpg").Length <= k && k < Directory.GetFiles (target).Length) 
            {
                StartCoroutine(loadMovie(k - dirInfo.GetFiles("*.jpg").Length));
                
            }
            else
            {
                StartCoroutine(loadPic(k));
            }
                
        }
        if (k > 0 && Input.GetKeyDown(KeyCode.A))
        { //減少
            k -= 1;
            
            if (dirInfo.GetFiles("*.jpg").Length <= k && k < Directory.GetFiles(target).Length)
            {
                StartCoroutine(loadMovie(k - dirInfo.GetFiles("*.jpg").Length));
                
            }
            else
                StartCoroutine(loadPic(k));
        }
    }
}


