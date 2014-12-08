using UnityEngine;
using System.Collections;

public class BallEngine : MonoBehaviour {

    float TimeOut = 1;
    float Speed = 5;
    int direction;
    GameObject Player;
    public GameObject diirectionOfShooting;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        diirectionOfShooting = GameObject.FindGameObjectWithTag("DirectionOfShooting");
	}
	
	// Update is called once per frame
	void Update () {
        if (diirectionOfShooting.transform.localPosition.x == -0.2f)
        {
            transform.position += Vector3.left * (Time.deltaTime * Speed);
        }
        else if (diirectionOfShooting.transform.localPosition.x == 0.2f)
        {
            transform.position += Vector3.right * (Time.deltaTime * Speed);
        }

        TimeOut -= Time.deltaTime;
        if (TimeOut <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
