using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class timespanBar2 : MonoBehaviour {
    public GameObject obj1;
    public GameObject obj2;
    public static int page_index = 1;
    public Text showText;
    public Text showText2;
    public string target = @"C:\Users\chile109\Desktop\武裝\";
    string xxx = "";
    public Animator myAnimator;
    public float fireRate = 5.0F;
    private float nextFire = 0.0F;
    private float nextFireB = 0.0F;
    // Use this for initialization
    void Start () {
        nextFire = Time.time + fireRate;
        page_index = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (page_index > Directory.GetFiles(@"C:\Users\chile109\Desktop\武裝\" + getFile.fileName.text).Length)
            page_index = Directory.GetFiles(@"C:\Users\chile109\Desktop\武裝\" + getFile.fileName.text).Length;

        xxx = page_index.ToString() + @"\" + Directory.GetFiles(@"C:\Users\chile109\Desktop\武裝\" + getFile.fileName.text).Length;
        showText.text = xxx;
        showText2.text = xxx;

        if (obj2.activeSelf == false && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Main_movie_show"))
        {
            myAnimator.SetInteger("play", 5);
           
        }
        
        if (Input.GetMouseButtonDown(0) && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Main_rawimage_close"))
            {                
                nextFire = Time.time + fireRate;
                myAnimator.SetInteger("play", 1);
        }
        if (Time.time > nextFire && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Main_rawimage_show"))
            {
                myAnimator.SetInteger("play", 0);
            }


        else if (obj2.activeSelf == true && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Main_rawimage_show"))
        {

            nextFireB = Time.time + fireRate;
            myAnimator.SetInteger("play", 2);
        }

        else if (Input.GetMouseButtonDown(0) && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Main_movie_close"))
        {
           
            nextFireB = Time.time + fireRate;
            
            myAnimator.SetInteger("play", 3);
        }

        else if (Time.time > nextFireB && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Main_movie_show"))
            {
            
                 myAnimator.SetInteger("play", 4);
            }
        

    }

  
}
