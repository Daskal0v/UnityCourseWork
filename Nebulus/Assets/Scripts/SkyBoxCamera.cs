using UnityEngine;
using System.Collections;

public class SkyBoxCamera : MonoBehaviour {

    private float speed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -speed * Time.deltaTime, 0);
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
	}
}
