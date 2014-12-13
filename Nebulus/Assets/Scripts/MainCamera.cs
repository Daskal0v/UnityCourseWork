using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
    public Transform Hero;
	// Use this for initialization
	void Start () {
        audio.volume = PlayerPrefs.GetFloat("Volume");
	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, Hero.position.y + 2.5f, transform.position.z);
        }
	}
}
