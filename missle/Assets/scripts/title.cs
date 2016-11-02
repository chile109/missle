using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {

    WWW mrwww;
    string url = "";
    RawImage player;
    AudioSource sound;
    MovieTexture movie;

    public string LoadScene = "武裝";


    // Use this for initialization
    void Start()
    {
        player = GetComponent<RawImage>();
        sound = GetComponent<AudioSource>();
        url = "file://" + @"C:\Users\chile109\Desktop\display\movies2.ogv";      //影片路徑
        mrwww = new WWW(url);
        movie = mrwww.movie;
        player.texture = movie;
        sound.clip = movie.audioClip;

        movie.Play();
        sound.Play();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(LoadScene);

        }
    }
}
