using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public void StartGame(string sceneName) 
    {
        Application.LoadLevel(sceneName);
	}
}
