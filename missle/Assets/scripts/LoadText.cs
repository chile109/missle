using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class LoadText : MonoBehaviour {
    List<WWW> trwww = new List<WWW>();
    
    string url = "";
    
    DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\chile109\Desktop\TEXT");
    
    public Text showText;
    int k = 0;
    void Start()
    {
        
        for (int i = 0; i < dirInfo.GetFiles("*.txt").Length ; i++)
        {

            url = "file://" + @"C:\Users\chile109\Desktop\TEXT\texts" + i + ".txt";
            Debug.Log(url);
            trwww.Add(new WWW(url));//加入文字陣列
            
        }
        
    }
	// Update is called once per frame
	void Update () {

        if (k < dirInfo.GetFiles("*.txt").Length -1 && Input.GetKeyDown(KeyCode.D))
        {
            k += 1;
            
        }
        if (k > 0 && Input.GetKeyDown(KeyCode.A))
        {
            k -= 1;
        }
        
        print(k);
        showText.text = trwww[k].text;
    }
}

