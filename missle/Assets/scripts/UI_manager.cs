using UnityEngine;
using System.Collections;

public class UI_manager : MonoBehaviour {
    public static int behave_id = 0;
    Animator player;
	// Use this for initialization
	void Start () {
        behave_id = 0;
        player = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (behave_id)
        {
            case 1:
                player.SetBool("go", true);
                break;

        }
            
            
	}
}
