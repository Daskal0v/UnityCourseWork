using UnityEngine;
using System.Collections;

public class BallEngine : MonoBehaviour {

    private bool isActive = true;
    private float timeOut = 1f;
    public float speed = 35f;
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

        timeOut -= Time.deltaTime;
        if (timeOut < 0f)
        {
            Destroy(this.gameObject);
        }

        if (!isActive)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter(Collider targetCollide)
    {
        if (targetCollide.gameObject.tag == "Target")
        {
            Destroy(targetCollide.gameObject);
            isActive = false;
        }
    }
}
