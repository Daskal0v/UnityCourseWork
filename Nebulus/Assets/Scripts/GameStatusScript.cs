using UnityEngine;
using System.Collections;

public class GameStatusScript : MonoBehaviour {
    public Texture2D texture; 
    void OnGUI()
    {
        
        GUI.Box(new Rect(1, 1, 100, 50), "Scores: " +PlayerPrefs.GetInt("Score")+ "\n Lives: "+ PlayerPrefs.GetInt("Lives"));

        if (PlayerPrefs.GetInt("Lives") < 1)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 70, 100,20), "GAME OVER");
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 25), "Back"))
            {
                Application.LoadLevel("menu");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 25), "Try Again?"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }

        
    }
}
