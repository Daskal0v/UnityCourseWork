using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStatusScript : MonoBehaviour {

    public Text Scores;
    public Text timer;
    //public Button TryAgain;
    //public Button Back;
    public Texture TryAgainTexture;
    public Texture BackToMenu;
    public Texture Exit;
    public RectTransform[] Lives = new RectTransform[3];
    float time = 0;
    bool showUI = false;
	void Start () {
        
	}
	

	void Update () {
        //Display Scores        
        Scores.text = PlayerPrefs.GetInt("Score").ToString();
        
        //Display Lives of Pogo
        if (PlayerPrefs.GetInt("Lives") == 3)
        {
            Lives[0].gameObject.SetActive(true);
            Lives[1].gameObject.SetActive(true);
            Lives[2].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Lives") == 2) 
        {
            Lives[0].gameObject.SetActive(true);
            Lives[1].gameObject.SetActive(true);
            Lives[2].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Lives") == 1)
        {
            Lives[0].gameObject.SetActive(true);
            Lives[1].gameObject.SetActive(false);
            Lives[2].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Lives") == 0)
        {
            Lives[0].gameObject.SetActive(false);
            Lives[1].gameObject.SetActive(false);
            Lives[2].gameObject.SetActive(false);
        }

        //Set timer 
        if (PlayerPrefs.GetInt("Lives") > 0) { 
            time += Time.deltaTime;
            timer.text = Mathf.Floor(time / 60).ToString("00")+":"+(time % 60).ToString("00");
            
        }
        else
        {
            //TryAgain.gameObject.SetActive(true);
            //Back.gameObject.SetActive(true);
            showUI = true;
        }
        


	}
    void OnGUI()
    {
        if (showUI)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 50, 50),TryAgainTexture))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (GUI.Button(new Rect(Screen.width / 2 , Screen.height / 2, 50, 50), BackToMenu))
            {
                Application.LoadLevel("menu");
            }
        }
        if (GUI.Button(new Rect(0, Screen.height - 50, 50, 50), Exit))
        {
            Application.LoadLevel("menu");
        }
    }

}
