using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {

    private bool isLoading = false;
    private string[] scenes;
    public float timer;
    public float secondsToLoadNextLevel = 7f;

	// Use this for initialization
	void Start () {
        scenes = new string[4]{"level1","level2","level3","level4"};
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > secondsToLoadNextLevel)
        {
            timer = 0;
        }

        if (timer == 0 && isLoading == true)
        {
            int scenesCount = 0;

            while (scenesCount < scenes.Length && scenesCount>=0)
            {
                scenesCount++;
                if (Application.loadedLevelName == scenes[scenesCount - 1] && scenes.Length > scenesCount)
                {
                    Application.LoadLevel(scenes[scenesCount]);
                }
                else if (Application.loadedLevelName == scenes[scenes.Length - 1])
                {
                    Application.LoadLevel("menu");
                }
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isLoading = true;
        }
    }
}
