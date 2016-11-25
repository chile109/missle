using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getFile : MonoBehaviour {

    public static Text fileName;
    
    public static int scene_index;


    public static string[] data_path = { @"C:\武裝\" ,  @"C:\Users\chile109\Desktop\武裝\"}; //讀取路徑資料庫

    public void loadfile()
    {
        fileName = GetComponent<Text>();
        print(fileName.text);   //Text為組件,text為內容  不用ToString();
        UI_manager.behave_id = 1;
        
        
    }

    public void go_Scene()
    {
        scene_index = Application.loadedLevel;   //儲存上一場景的編號
        SceneManager.LoadSceneAsync("MAIN2");
    }
}
