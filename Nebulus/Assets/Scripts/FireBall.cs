using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(Time.deltaTime+0.05f,0,0);
        if (transform.position.x <= -10f) {
            Destroy(this.gameObject);
        }           
	}

}
