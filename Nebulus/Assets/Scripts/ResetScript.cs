using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {

    public void playAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void backToMenu()
    {
        Application.LoadLevel("menu");
    }
    public void ResetPoints()
    {
        PlayerPrefs.DeleteKey("Scores");
    }
}
