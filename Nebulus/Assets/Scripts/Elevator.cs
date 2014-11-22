using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public float height = 0;

	// Use this for initialization
	void Start () 
    {
        transform.LookAt(new Vector3(0, transform.position.y, 0));
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Activate()
    {
        Debug.Log("Elevate!!!");
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, height, transform.position.z), 10);
    }
}
