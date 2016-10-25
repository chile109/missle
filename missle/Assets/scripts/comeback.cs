using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class comeback : MonoBehaviour {
    public string scene = "MENU";
    public void BackMenu()
    {
        SceneManager.LoadScene(scene);

    }
}
