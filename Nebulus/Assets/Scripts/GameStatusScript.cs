using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStatusScript : MonoBehaviour {
    public Text txt;
    public RectTransform[] Lives = new RectTransform[3];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = PlayerPrefs.GetInt("Score").ToString();
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
	}
}
