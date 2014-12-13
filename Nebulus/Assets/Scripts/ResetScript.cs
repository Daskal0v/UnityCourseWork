using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {

    public void playAgain(bool isClick)
    {
        //Debug.Log("asads");
        //Debug.Log(isClick);
        Application.LoadLevel(Application.loadedLevel);
    }
    public void backToMenu()
    {
        Application.LoadLevel("menu");
    }
    public void ResetPoints()
    {
        PlayerPrefs.DeleteKey("Score");
    }
}
