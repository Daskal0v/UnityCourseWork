using UnityEngine;
using System.Collections;

public class BallEngine : MonoBehaviour {

    float TimeOut = 1f;
    float speed = 20f;
    public GameObject diirectionOfShooting;

	// Use this for initialization
	void Start () {
        diirectionOfShooting = GameObject.FindGameObjectWithTag("DirectionOfShooting");
	}
	
	// Update is called once per frame
	void Update () {
        if (diirectionOfShooting.transform.localPosition.x == -0.2f)
        {
            transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
        }
        else if (diirectionOfShooting.transform.localPosition.x == 0.2f)
        {
            transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime * -1);
        }

        TimeOut -= Time.deltaTime;
        if (TimeOut < 0f)
        {
            Destroy(this.gameObject);
        }
	}

    //TODO: Collisions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
        }
    }
}
