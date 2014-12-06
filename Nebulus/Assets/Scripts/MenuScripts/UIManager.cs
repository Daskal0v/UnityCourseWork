using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Animator playButton;
    public Animator settingsButton;
    public Animator aboutButton;

    public void OpenSettings()
    {
        playButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        aboutButton.SetBool("isHidden", true);
    }

	public void StartGame(string sceneName) 
    {
        Application.LoadLevel(sceneName);
	}
}
