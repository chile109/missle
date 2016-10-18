using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getFile : MonoBehaviour {

    public static Text fileName;


    public void loadfile()
    {
        fileName = GetComponent<Text>();
        print(fileName.text);   //Text為組件,text為內容  不用ToString();
        SceneManager.LoadScene("MAIN");

    }
}
