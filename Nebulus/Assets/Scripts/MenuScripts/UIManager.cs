using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Animator playButton;
    public Animator settingsButton;
    public Animator aboutButton;
    public Animator settingsPanel;
    public Animator teamPanel;

    public void OpenSettings()
    {
        playButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        aboutButton.SetBool("isHidden", true);

        settingsPanel.SetBool("isHidden", false);
    }

    public void CloseSettings()
    {
        playButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        aboutButton.SetBool("isHidden", false);
        settingsPanel.SetBool("isHidden", true);
    }

    public void OpenAbout()
    {
        playButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        aboutButton.SetBool("isHidden", true);

        teamPanel.SetBool("isHidden", false);
    }

    public void CloseAbout()
    {
        playButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        aboutButton.SetBool("isHidden", false);

        teamPanel.SetBool("isHidden", true);
    }

	public void StartGame(string sceneName) 
    {
        Application.LoadLevel(sceneName);
	}
}
