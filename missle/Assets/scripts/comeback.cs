using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class comeback : MonoBehaviour {
    public string scene = "MENU";
    public void BackMenu()
    {
        SceneManager.LoadScene(getFile.scene_index);

    }
}
