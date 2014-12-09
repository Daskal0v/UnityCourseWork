using UnityEngine;
using System.Collections;

public class CharacterShooting : MonoBehaviour {

    GameObject diirectionOfShooting;
    GameObject ball;

	// Use this for initialization
	void Start () {
        diirectionOfShooting = GameObject.FindGameObjectWithTag("DirectionOfShooting");
        ball = (GameObject)Resources.Load("Ball");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            diirectionOfShooting.transform.localPosition = new Vector3(-0.2f, 0, 0f);
        }

        // Walk right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            diirectionOfShooting.transform.localPosition = new Vector3(0.2f, 0, 0f);
        }
        
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(ball, diirectionOfShooting.transform.position, diirectionOfShooting.transform.rotation);
        }
        else
        {
            CancelInvoke("Ball");
        }
    }
   
}
