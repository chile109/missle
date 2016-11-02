using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getFile : MonoBehaviour {

    public static Text fileName;
    
    public static int scene_index;
    public void loadfile()
    {
        fileName = GetComponent<Text>();
        print(fileName.text);   //Text為組件,text為內容  不用ToString();
        UI_manager.behave_id = 1;
        
        
    }

    public void go_Scene()
    {
        scene_index = Application.loadedLevel;
        SceneManager.LoadSceneAsync("MAIN2");
    }
}
